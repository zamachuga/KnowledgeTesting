using KnowledgeTesting.BL.DB.PgSql;
using DAO = KnowledgeTesting.BL.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL;

namespace KnowledgeTestingTests
{
	/// <summary>
	/// Интеграционное тестирование по сценариям.
	/// </summary>
	//[Ignore("Интеграционный тест проускаем, его не надо каждый раз запускать.")]
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

			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = Questions.Q1 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = Questions.Q2 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = Questions.Q3 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = Questions.Q4 });
			_QuestionManagement.CreateQuestion(new DAO.Question() { Text = Questions.Q5 });

			_DbContext.SaveChanges();

			var _Result = _QuestionManagement.GetQuestion(Questions.Q4);

			Assert.True(_Result != null & _Result.Id > 0);
		}

		/// <summary>
		/// Добавить ответ в вопрос.
		/// </summary>
		[Test]
		public void AddAswerToQuestion()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();
			AnswerManagement _AnswerManagement = new AnswerManagement();

			DAO.Question _Question = _QuestionManagement.GetQuestion(Questions.Q1);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A1));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A2));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A3));

			_Question = _QuestionManagement.GetQuestion(Questions.Q2);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A4));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A5));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A6));

			_Question = _QuestionManagement.GetQuestion(Questions.Q3);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A7));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A8));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A9));

			_Question = _QuestionManagement.GetQuestion(Questions.Q4);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A10));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A11));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A12));

			_Question = _QuestionManagement.GetQuestion(Questions.Q5);
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A13));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A14));
			_QuestionManagement.AddAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A15));

			_DbContext.SaveChanges();

			Assert.True(_Question.Answers.Count() == 3);
			Assert.True(_Question.Answers.Where(x => x.AnswerId == _AnswerManagement.GetAnswer(Answers.A14).Id).Count() == 1);
		}

		/// <summary>
		/// Установить правильный ответ для вопроса.
		/// </summary>
		[Test]
		public void SetCorrectAnswerToQuestion()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();
			AnswerManagement _AnswerManagement = new AnswerManagement();

			DAO.Question _Question = _QuestionManagement.GetQuestion(Questions.Q1);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A1));

			_Question = _QuestionManagement.GetQuestion(Questions.Q2);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A6));

			_Question = _QuestionManagement.GetQuestion(Questions.Q3);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A7));

			_Question = _QuestionManagement.GetQuestion(Questions.Q4);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A11));

			_Question = _QuestionManagement.GetQuestion(Questions.Q5);
			_QuestionManagement.SetCorrectAnswer(_Question, _AnswerManagement.GetAnswer(Answers.A13));

			_DbContext.SaveChanges();

			Assert.True(_Question.Answers.Where(x => x.AnswerId == _AnswerManagement.GetAnswer(Answers.A13).Id & x.IsCorrect).Count() == 1);
		}
	}

	public static class Questions
	{
		public const string Q1 = "Вторая планета Солнечной системы?";
		public const string Q2 = "Число 27 в двоичной системе исчисления?";
		public const string Q3 = "Примерное количество людей на Земле?";
		public const string Q4 = "Кто написал «Сказка о царе Салтане»?";
		public const string Q5 = "Сколько граней у куба?";
	}

	public static class Answers
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

