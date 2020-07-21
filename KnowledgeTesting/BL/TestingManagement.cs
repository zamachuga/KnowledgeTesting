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
			return null;
			//DAO.Question _NextQuestion = from q in InterviweeTest.Test.Questions
			//														 where _DbContext.TestingResults.SingleOrDefault(x => x.IsCorrect == false).tofi
			//														 ;
		}
	}
}