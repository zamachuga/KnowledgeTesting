using System;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;
using System.Linq;
using NUnit.Framework;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестами.
	/// </summary>
	public class TestManagement
	{
		DB.PgSql.DbPgSqlContext _DbContext = DB.PgSql.DbPgSqlContext.Instance();

		public void CreateTest(DAO.Test Test)
		{
			if (IsExist(Test)) return;

			_DbContext.Tests.Add(Test);
		}

		public void AddQuestion(DAO.Test Test, DAO.Question Question)
		{
			if (Test.Questions.Count() >= 10) throw new Exception("В тесте максимум 10 вопрсов.");
			if (Question.Answers.Where(x => x.IsCorrect).Count() == 0) throw new Exception("В вопросе не указан правильный ответ.");

			DAO.TestQuestions _TestQuestion = new DAO.TestQuestions() { TestId = Test.Id, QuestionId = Question.Id };
			_DbContext.TestQuestions.Add(_TestQuestion);
		}

		/// <summary>
		/// Проверить существование теста в БД.
		/// </summary>
		private bool IsExist(DAO.Test Test)
		{
			DAO.Test _FinKey = _DbContext.Tests.Find(Test.Id);
			int _FindText = _DbContext.Tests.Where(x => x.Name.ToLower().Replace(" ", "") == Test.Name.ToLower().Replace(" ", "")).Count();

			bool _IsExist = _FinKey != null || _FindText > 0;
			return _IsExist;
		}

		/// <summary>
		/// Получить список тестов.
		/// </summary>
		/// <returns></returns>
		public DAO.Test[] GetListTests()
		{
			return _DbContext.Tests.ToArray();
		}
	}
}