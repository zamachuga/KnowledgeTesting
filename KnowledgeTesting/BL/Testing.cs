using KnowledgeTesting.BL.DB.PgSql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление проведением тестирования.
	/// </summary>
	public class Testing
	{
		private DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

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
			// Если прохождение теста завершено.
			if (InterviweeTest.IsComplete) return null;

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
				Random _Random = new Random(Guid.NewGuid().GetHashCode());
				int _NextQuestion = _Random.Next(0, Questions.Count() - 1);
				return Questions[_NextQuestion].Question;
			}

			return null;
		}

		/// <summary>
		/// Ответить на вопрос.
		/// </summary>
		/// <param name="InterviweeTestId">Прохождение теста.</param>
		/// <param name="QuestionId">Вопрос.</param>
		/// <param name="AnswerId">Ответ.</param>
		public void AnswerToQuestion(DAO.InterviweeTests InterviweeTest, DAO.Question Question, DAO.Answer Answer)
		{
			// Если ответ на такой вопрос уже был - выходим.
			var ExistAnswer = _DbContext.TestingResults.Where(x =>
				x.InterviweeTestsId == InterviweeTest.Id
				& x.QuestionId == Question.Id).Count();
			if (ExistAnswer > 0) return;

			// Определить ответ.
			DAO.TestingResult _TestingResult = new DAO.TestingResult()
			{
				InterviweeTestsId = InterviweeTest.Id,
				QuestionId = Question.Id,
				AnswerId = Answer.Id,
				IsCorrect = _DbContext.QuestionAnswers.Where(x => x.QuestionId == Question.Id & x.IsCorrect).FirstOrDefault()?.AnswerId == Answer.Id
			};

			// Добавить в результаты теста.
			_DbContext.TestingResults.Add(_TestingResult);

			// Определить статус прохождения теста.
			InterviweeTest.IsComplete = IsAllAnswersTest(InterviweeTest);
			if (_DbContext.Entry(InterviweeTest).State != EntityState.Unchanged) _DbContext.SaveChanges();
		}

		/// <summary>
		/// Получить статус завершения теста по количеству ответов.
		/// </summary>
		/// <returns></returns>
		public bool IsAllAnswersTest(DAO.InterviweeTests InterviweeTest)
		{
			// Количество вопросов с ответом.
			int _CounTestResults = _DbContext.TestingResults.Where(x => x.InterviweeTestsId == InterviweeTest.Id).Count();
			// Количество вопросов в тесте.
			int _CountTestQustions = _DbContext.TestQuestions.Where(x => x.TestId == InterviweeTest.TestId).Count();

			return _CounTestResults >= _CountTestQustions;
		}
	}
}