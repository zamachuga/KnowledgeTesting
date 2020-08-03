using KnowledgeTesting.BL.DAO;
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
	public class Testing : ITesting
	{
		private Testing() { }
		public static ITesting Instance() { return new Testing(); }

		private DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		/// <summary>
		/// Начать/получить процесс тестирования.
		/// </summary>
		public DAO.InterviweeTests StartTesting(DAO.Interviwee Interviwee, DAO.Test Test)
		{
			DAO.InterviweeTests _InterviweeTest = GetTesting(Interviwee, Test);

			// Не нашли - создать прохождение теста.
			if (_InterviweeTest != null) return _InterviweeTest;

			_InterviweeTest = new DAO.InterviweeTests()
			{
				InterviweeId = Interviwee.Id,
				TestId = Test.Id,
				IsComplete = false
			};

			return StartTesting(_InterviweeTest);
		}

		/// <summary>
		/// Начать/получить процесс тестирования.
		/// </summary>
		private DAO.InterviweeTests StartTesting(DAO.InterviweeTests InterviweeTest)
		{
			DAO.InterviweeTests _InterviweeTest = _DbContext.InterviweeTests.Add(InterviweeTest);
			_DbContext.SaveChanges();

			return _InterviweeTest;
		}

		/// <summary>
		/// Получить процесс тестирования.
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public InterviweeTests GetTesting(int Id)
		{
			// Найдем незавершенный тест.
			DAO.InterviweeTests _InterviweeTest = _DbContext.InterviweeTests
				.Include(x => x.Test)
				.Include(x => x.Interviwee)
				.Include(x => x.TestingResults)
				.Where(x => x.Id == Id)
				.SingleOrDefault();

			return _InterviweeTest;
		}

		/// <summary>
		/// Получить процесс тестирования.
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		internal InterviweeTests GetTesting(DAO.Interviwee Interviwee, DAO.Test Test)
		{
			// Найдем незавершенный тест.
			// Сначала необходимо завершить предыдущий, потом начинать заново.
			DAO.InterviweeTests _InterviweeTest = _DbContext.InterviweeTests
				.Include(x => x.Test)
				.Include(x => x.Interviwee)
				.Include(x => x.TestingResults)
				.Where(x => x.InterviweeId == Interviwee.Id & x.TestId == Test.Id & x.IsComplete == false)
				.SingleOrDefault();

			return _InterviweeTest;
		}

		/// <summary>
		/// Получить следующий вопрос для прохождения теста.
		/// </summary>
		/// <param name="InterviweeTests">Прохождение теста.</param>
		/// <returns></returns>
		public DAO.Question GetNextQuestion(DAO.InterviweeTests InterviweeTest, DAO.Question ExcludeQuestion = null)
		{
			// Если прохождение теста завершено.
			if (InterviweeTest.IsComplete) return null;

			// Получим массив вопросов с ответами.
			DAO.Question[] _QuestionResults = _DbContext.TestingResults
				.Where(x => x.InterviweeTestsId == InterviweeTest.Id)
				.Select(x => x.Question)
				.ToArray();

			// Получим массив вопросов теста.
			DAO.Question[] _QuestionsTest = _DbContext.TestQuestions
				.Where(x => x.TestId == InterviweeTest.TestId)
				.Select(x => x.Question)
				.ToArray();

			// Получим массив незаданных вопросов.
			DAO.Question[] _QuestionsNotAnswer = _QuestionsTest.Except(_QuestionResults).ToArray();

			// Случайный вопрос.
			DAO.Question _Question = RandomQuestion(_QuestionsNotAnswer, ExcludeQuestion);

			return _Question;
		}

		/// <summary>
		/// Получить количество ответов на вопрсы.
		/// </summary>
		public int GetCountCompletedQuestion(DAO.InterviweeTests InterviweeTest)
		{
			int _CompletedQuestion = InterviweeTest.TestingResults.Count();

			return _CompletedQuestion;
		}

		/// <summary>
		/// Получить количество вопросов.
		/// </summary>
		public int GetCountQuestions(DAO.InterviweeTests InterviweeTest)
		{
			int _CountQuestions = InterviweeTest.Test.Questions.Count();

			return _CountQuestions;
		}

		/// <summary>
		/// Получить количество правильных ответов.
		/// </summary>
		public int GetCountCorrectAnswers(DAO.InterviweeTests InterviweeTest)
		{
			int _CorrectAnswers = InterviweeTest.TestingResults.Where(x => x.IsCorrect).Count();

			return _CorrectAnswers;
		}

		/// <summary>
		/// Выбрать случайный вопрос.
		/// </summary>
		/// <param name="Questions">Вопросы</param>
		/// <param name="ExcludeQuestion">Вопрос для исключения из выборки. Не сработает если этот вопрос последний.</param>
		/// <returns></returns>
		public DAO.Question RandomQuestion(DAO.Question[] Questions, DAO.Question ExcludeQuestion = null)
		{
			DAO.Question[] _Questions = null;

			// Исключим из выборки указанный вопрос.
			if (Questions.Count() > 1 && ExcludeQuestion != null)
				_Questions = Questions.Where(x => x.Id != ExcludeQuestion.Id).ToArray();
			else
				_Questions = Questions;

			// Получим следующий случайный вопрос.
			if (_Questions.Length > 0)
			{
				Random _Random = new Random(Guid.NewGuid().GetHashCode());
				int _MaxRangeNext = _Questions.Count() - 1;
				int _NextQuestion = _Random.Next(0, _MaxRangeNext);
				return _Questions[_NextQuestion];
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
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Опделить статус завершения теста.
		/// </summary>
		/// <returns></returns>
		public void DetermineStatusComplete(DAO.InterviweeTests InterviweeTest)
		{
			// Количество вопросов с ответом.
			int _CounTestResults = _DbContext.TestingResults.Where(x => x.InterviweeTestsId == InterviweeTest.Id).Count();
			// Количество вопросов в тесте.
			int _CountTestQustions = _DbContext.TestQuestions.Where(x => x.TestId == InterviweeTest.TestId).Count();

			// Сохраним в БД состояние теста.
			InterviweeTest.IsComplete = _CounTestResults >= _CountTestQustions;
			_DbContext.SaveChanges();
		}
	}
}