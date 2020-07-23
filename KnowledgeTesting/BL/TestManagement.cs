using System;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;
using System.Linq;
using NUnit.Framework;
using KnowledgeTesting.BL.DAO;

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
			if (Test.Questions.Where(x => x.QuestionId == Question.Id).Count() == 1) return;
			if (Test.Questions.Count() >= 10) throw new Exception("В тесте максимум 10 вопрсов.");
			if (Question.Answers.Where(x => x.IsCorrect).Count() == 0) throw new Exception("В вопросе не указан правильный ответ.");

			DAO.TestQuestions _TestQuestion = new DAO.TestQuestions() { TestId = Test.Id, QuestionId = Question.Id };
			_DbContext.TestQuestions.Add(_TestQuestion);
		}

		/// <summary>
		/// Получить все тесты.
		/// </summary>
		/// <returns></returns>
		public Test[] GetAllTests()
		{
			var _AllTests = _DbContext.Tests.ToArray();
			return _AllTests;
		}

		/// <summary>
		/// Проверить существование теста в БД.
		/// </summary>
		private bool IsExist(DAO.Test Test)
		{
			DAO.Test _FinKey = GetTest(Test.Id);
			DAO.Test _FindText = GetTest(Test.Name);

			bool _IsExist = _FinKey != null || _FindText != null;
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

		/// <summary>
		/// Получить тест по названию.
		/// </summary>
		public DAO.Test GetTest(string Name)
		{
			var _Test = _DbContext.Tests.Where(x => x.Name.ToLower().Replace(" ", "") == Name.ToLower().Replace(" ", "")).FirstOrDefault();
			return _Test;
		}

		/// <summary>
		/// Получить тест по коду.
		/// </summary>
		public DAO.Test GetTest(int id)
		{
			var _Test = _DbContext.Tests.Find(id);
			return _Test;
		}
	}
}