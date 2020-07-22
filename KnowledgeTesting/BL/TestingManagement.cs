using KnowledgeTesting.BL.DB.PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление проведением тестирования.
	/// </summary>
	public class TestingManagement
	{
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		/// <summary>
		/// Начать тестирование.
		/// </summary>
		public DAO.InterviweeTests StartTest(DAO.Interviwee Interviwee, DAO.Test Test)
		{
			DAO.InterviweeTests _InterviweeTest = null;

			// Найдем незавершенный тест.
			_InterviweeTest = _DbContext.InterviweeTests
				.Where(x => x.InterviweeId == Interviwee.Id & x.TestId == Test.Id & x.IsComplete == false)
				.SingleOrDefault();

			// Не нашли - создать прохождение теста.
			if (_InterviweeTest == null)
			{
				_InterviweeTest = new DAO.InterviweeTests()
				{
					InterviweeId = Interviwee.Id,
					TestId = Test.Id,
					IsComplete = false
				};

				_InterviweeTest = _DbContext.InterviweeTests.Add(_InterviweeTest);
			}

			return _InterviweeTest;
		}

		/// <summary>
		/// Получить следующий вопрос для прохождения теста.
		/// </summary>
		/// <param name="InterviweeTests">Прохождение теста.</param>
		/// <returns></returns>
		public DAO.Question GetNextQuestion(DAO.InterviweeTests InterviweeTest)
		{
			// Получим вопросы на которые еще не ответили.
			DAO.TestQuestions[] _QuestionsNotAnswer = (
				// Вопросы из теста.
				from q in InterviweeTest.Test.Questions
					// На которые еще нет ответа.
				where _DbContext.TestingResults.SingleOrDefault(x => x.Question.Equals(q)) == null
				select q
			).AsEnumerable().ToArray();

			DAO.Question _Question = RandomQuestion(_QuestionsNotAnswer);
			return _Question;
		}

		/// <summary>
		/// Выбрать случайный вопрос.
		/// </summary>
		/// <param name="Questions">Вопросы</param>
		/// <returns></returns>
		public DAO.Question RandomQuestion(DAO.TestQuestions[] Questions)
		{
			// Получим следующий случайный вопрос.
			if (Questions.Length > 0)
			{
				Random _R = new Random();
				int _NextQuestion = _R.Next(0, Questions.Count() - 1);
				return Questions[_NextQuestion].Question;
			}

			return null;
		}
	}
}