using KnowledgeTesting.BL.DB.PgSql;
using DAO = KnowledgeTesting.BL.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL;
using KnowledgeTesting.Migrations;
using KnowledgeTesting.Controllers;

namespace KnowledgeTestingTests
{
	/// <summary>
	/// Интеграционное тестирование по сценариям.
	/// </summary>
	[Ignore("Интеграционный тест проускаем, его не надо каждый раз запускать.")]
	[TestFixture]
	public class IntegrationTests
	{
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		[Test]
		public void CreateQuestionTest()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();

			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = StaticQuestions.Q1 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = StaticQuestions.Q2 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = StaticQuestions.Q3 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = StaticQuestions.Q4 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = StaticQuestions.Q5 });

			_DbContext.SaveChanges();

			var _Result = _QuestionManagement.GetQuestion(StaticQuestions.Q4);

			Assert.True(_Result != null & _Result.Id > 0);
		}

		/// <summary>
		/// Добавить ответ в вопрос.
		/// </summary>
		[Test]
		public void AddAswerToQuestionTest()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();
			AnswerManagement _AnswerManagement = new AnswerManagement();

			DAO.Question _Question = _QuestionManagement.GetQuestion(StaticQuestions.Q1);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A1));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A2));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A3));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q2);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A4));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A5));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A6));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q3);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A7));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A8));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A9));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q4);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A10));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A11));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A12));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q5);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A13));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A14));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A15));

			_DbContext.SaveChanges();

			Assert.True(_Question.Answers.Count() == 3);
			Assert.True(_Question.Answers.Where(x => x.AnswerId == _AnswerManagement.GetAnswer(StaticAnswers.A14).Id).Count() == 1);
		}

		/// <summary>
		/// Установить правильный ответ для вопроса.
		/// </summary>
		[Test]
		public void SetCorrectAnswerToQuestionTest()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();
			AnswerManagement _AnswerManagement = new AnswerManagement();

			DAO.Question _Question = _QuestionManagement.GetQuestion(StaticQuestions.Q1);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A1));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q2);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A6));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q3);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A7));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q4);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A11));

			_Question = _QuestionManagement.GetQuestion(StaticQuestions.Q5);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(StaticAnswers.A13));

			_DbContext.SaveChanges();

			Assert.True(_Question.Answers.Where(x => x.AnswerId == _AnswerManagement.GetAnswer(StaticAnswers.A13).Id & x.IsCorrect).Count() == 1);
		}

		/// <summary>
		/// Создать тест.
		/// </summary>
		[Test]
		public void CreateTest()
		{
			TestManagement _TestManagement = new TestManagement();

			DAO.Test _Test = new DAO.Test() { Name = StaticTests.T1, Description = "Проверка создания тестов." };

			_TestManagement.CreateTest(_Test);
			_DbContext.SaveChanges();

			Assert.True(_TestManagement.GetTest(StaticTests.T1).Id > 0);
		}

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		[Test]
		public void AddQuestionToTest()
		{
			TestManagement _TestManagement = new TestManagement();
			QuestionManagement _QuestionManagement = new QuestionManagement();

			DAO.Test _Test = _TestManagement.GetTest(StaticTests.T1);
			_TestManagement.AddQuestion(_Test, _QuestionManagement.GetQuestion(StaticQuestions.Q1));
			_TestManagement.AddQuestion(_Test, _QuestionManagement.GetQuestion(StaticQuestions.Q2));
			_TestManagement.AddQuestion(_Test, _QuestionManagement.GetQuestion(StaticQuestions.Q3));
			_TestManagement.AddQuestion(_Test, _QuestionManagement.GetQuestion(StaticQuestions.Q4));
			_TestManagement.AddQuestion(_Test, _QuestionManagement.GetQuestion(StaticQuestions.Q5));
			_DbContext.SaveChanges();

			Assert.True(_Test.Questions.Where(x => x.QuestionId == _QuestionManagement.GetQuestion(StaticQuestions.Q3).Id).Count() == 1);
		}

		/// <summary>
		/// Создать тестируемого.
		/// </summary>
		[Test]
		public void CreateInterviewerTest()
		{
			InterviweeManagement _InterviweeManagement = new InterviweeManagement();

			DAO.Interviwee _Interviwee = new DAO.Interviwee()
			{
				LasName = StaticInterviwee.LasName,
				FirstName = StaticInterviwee.FirstName,
				SecondName = StaticInterviwee.SecondName
			};

			_InterviweeManagement.CreateInterviwee(_Interviwee);
			_DbContext.SaveChanges();

			_Interviwee = _InterviweeManagement.GetInterviwee(StaticInterviwee.LasName, StaticInterviwee.FirstName, StaticInterviwee.SecondName);
			Assert.True(
				_DbContext.Interviwees.Where(x =>
					x.Id == _Interviwee.Id
				).Count() == 1
			);
		}

		/// <summary>
		/// Пройти тест.
		/// </summary>
		[Test]
		public void TestingTest()
		{
			TestManagement _TestManagement = new TestManagement();
			InterviweeManagement _InterviweeManagement = new InterviweeManagement();
			KnowledgeTesting.BL.Testing _Testing = new KnowledgeTesting.BL.Testing();

			

			DAO.Interviwee _Interviwee = _InterviweeManagement.GetInterviwee(StaticInterviwee.LasName, StaticInterviwee.FirstName, StaticInterviwee.SecondName);
			DAO.Test _Test = _TestManagement.GetTest(StaticTests.T1);

			int _CountCompleteTeststBefore = _Interviwee.Tests.Count();				

			DAO.InterviweeTests _InterviweeTests = _Testing.StartTest(_Interviwee, _Test);

			// Количество отвеченных вопросов 
			// (в конце на 1 больше чем вопрсов из-за последнего прохода цикла для определения статуса завершения).
			int _CountQuestions = 0;
			while (!_InterviweeTests.IsComplete)
			{
				// Определить статус завершения.
				_InterviweeTests.IsComplete = _Testing.DetermineStatusComplete(_InterviweeTests);

				if (!_InterviweeTests.IsComplete)
				{
					// Получить следующий вопрос.
					DAO.Question _Question = _Testing.GetNextQuestion(_InterviweeTests);
					// Отвтеить на вопрос.
					if (_Question != null)
						_Testing.AnswerToQuestion(_InterviweeTests, _Question, _Question.Answers.First().Answer);
				}

				// Сохранить изменения - БЕЗ этого не возможно определить статус завершения теста.
				_DbContext.SaveChanges();

				_CountQuestions++;
				Assert.True(_CountQuestions <= 10);
			}

			int _CountCompleteTeststAfter = _Interviwee.Tests.Count();

			Assert.True(_DbContext.InterviweeTests.Where(x => x.Id == _InterviweeTests.Id).First().IsComplete);
			Assert.True(_CountCompleteTeststAfter > _CountCompleteTeststBefore);
			Assert.True(_InterviweeTests.TestingResults.Count() > 0);
		}

		[Ignore("Временный тест для конкрнетного случая.")]
		[Test]		
		public void GetListQuestionForTestTest()
		{
			TestManagementController _Controller = new TestManagementController();
			var Json = _Controller.GetListQuestionForTest(13);
		}
	}

	public static class StaticInterviwee
	{
		public const string LasName = "Фамилия";
		public const string FirstName = "Имя";
		public const string SecondName = "Отчество";
	}

	public static class StaticTests
	{
		public static string T1 = "StaticTests";
	}

	public static class StaticQuestions
	{
		public const string Q1 = "Вторая планета Солнечной системы?";
		public const string Q2 = "Число 27 в двоичной системе исчисления?";
		public const string Q3 = "Примерное количество людей на Земле?";
		public const string Q4 = "Кто написал «Сказка о царе Салтане»?";
		public const string Q5 = "Сколько граней у куба?";
	}

	public static class StaticAnswers
	{
		public const string A1 = "Венера";
		public const string A2 = "Меркурий";
		public const string A3 = "Земля";

		public const string A4 = "111000";
		public const string A5 = "101010";
		public const string A6 = "11011";

		public const string A7 = "7 млрд.";
		public const string A8 = "10 млрд.";
		public const string A9 = "5млрд.";

		public const string A10 = "Лермонтов";
		public const string A11 = "Пушкин";
		public const string A12 = "Некрасов";

		public const string A13 = "6";
		public const string A14 = "8";
		public const string A15 = "12";
	}
}