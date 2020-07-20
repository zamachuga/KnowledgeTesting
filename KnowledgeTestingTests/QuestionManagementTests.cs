using KnowledgeTesting.BL;
using DAO = KnowledgeTesting.BL.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework.Constraints;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class QuestionManagementTests
	{
		QuestionManagement _QuestionManagement = new QuestionManagement();
		DbPgSqlContext _DbContext = new DbPgSqlContext();

		[Test]
		public void AddAnswerMax3Test()
		{
			DAO.Question _Question = new DAO.Question();

			Assert.DoesNotThrow(() => _QuestionManagement.AddAnswer(_Question, new DAO.Answer() { }));
			Assert.DoesNotThrow(() => _QuestionManagement.AddAnswer(_Question, new DAO.Answer() { }));
			Assert.DoesNotThrow(() => _QuestionManagement.AddAnswer(_Question, new DAO.Answer() { }));
			Assert.Throws<Exception>(() => _QuestionManagement.AddAnswer(_Question, new DAO.Answer() { }));
		}

		[Test]
		public void SetCorrectAnswerTest()
		{
			DAO.Question _Question = new DAO.Question();

			var _Answer1 = new DAO.Answer() { };
			var _Answer2 = new DAO.Answer() { };
			var _Answer3 = new DAO.Answer() { };
			var _Answer4 = new DAO.Answer() { };
			_QuestionManagement.AddAnswer(_Question, _Answer1);
			_QuestionManagement.AddAnswer(_Question, _Answer2);
			_QuestionManagement.AddAnswer(_Question, _Answer3);

			Assert.DoesNotThrow(() => _QuestionManagement.SetCorrectAnswer(_Question, _Answer3));
			Assert.Throws<Exception>(() => _QuestionManagement.SetCorrectAnswer(_Question, _Answer4));
		}

		/// <summary>
		/// Создание вопроса без ответов.
		/// </summary>
		[Test]
		public void CreateQuestionNotAnswersTest()
		{
			DAO.Question _Question = new DAO.Question() { Text = "wtf?" };

			Assert.DoesNotThrow(() => _QuestionManagement.CreateQuestion(_Question));
			Assert.True(_DbContext.Questions.Where(x => x.Text == _Question.Text).Count() == 1);
		}

		/// <summary>
		/// Создание вопроса с ответами.
		/// </summary
		[Test]
		public void CreateQuestionAnswersTest()
		{
			DAO.Question _Question = new DAO.Question() { Text = "Вторая планета Солнечной системы?" };
			// Удаляем созданный вопрос, т.к. если вопрос существует то тест пойдет уже не так.
			_DbContext.Questions.Remove(_DbContext.Questions.First(x => x.Text == _Question.Text));
			_DbContext.SaveChanges();

			DAO.Answer[] _Answers = new DAO.Answer[]{
				_DbContext.Answers.First(x => x.Text == "Венера"),
				_DbContext.Answers.First(x => x.Text == "Меркурий"),
				_DbContext.Answers.First(x => x.Text == "Земля")
			};
			_QuestionManagement.AddAnswer(_Question, _Answers);

			// Создаем вопрос до того, как назначили правильный ответ - ошибка.
			Assert.Throws<Exception>(() => _QuestionManagement.CreateQuestion(_Question));

			// Назначаем правильный ответ и создаем вопрос - верно.
			_QuestionManagement.SetCorrectAnswer(_Question, _DbContext.Answers.First(x => x.Text == "Венера"));
			Assert.DoesNotThrow(() => _QuestionManagement.CreateQuestion(_Question));

			// Мелкие проверки на всякий случай.
			Assert.True(_DbContext.Questions.Where(x => x.Text == _Question.Text).Count() == 1);
			Assert.True(_DbContext.Answers.Where(x => x.Text == "Венера").Count() == 1);
		}
	}
}
