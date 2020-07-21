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
using System.Data.Entity;
using Moq;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class QuestionManagementTests
	{
		QuestionManagement _QuestionManagement = new QuestionManagement();
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		[Test]
		public void AddAnswerMax3Test()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				var _Question = new Mock<DAO.Question>();
				var _QuestionAnswers = new Mock<DAO.QuestionAnswers>();
				List<DAO.QuestionAnswers> _Answers = new List<DAO.QuestionAnswers>() { _QuestionAnswers.Object, _QuestionAnswers.Object, _QuestionAnswers.Object };

				_Question.Setup(x => x.Answers).Returns(_Answers);

				Assert.Throws<Exception>(() => _QuestionManagement.AddAnswer(_Question.Object, new DAO.Answer() { }));

				_Transaction.Rollback();
			}
		}

		[Test]
		public void SetCorrectAnswerTest()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				// Создаем вопрос.
				DAO.Question _Question = new DAO.Question() { Text = "SetCorrectAnswerTest?" };
				_QuestionManagement.CreateQuestion(_Question);
				_DbContext.SaveChanges();

				// Получаем сущность из БД - если не получить, то EF подумает, что надо создать новую.
				_Question = _DbContext.Questions.Include("Answers").Single(x => x.Text == _Question.Text);

				// Выбираем ответы для заполнения.
				DAO.Answer[] _Answers = new DAO.Answer[]{
						_DbContext.Answers.Single(x => x.Text == "Венера"),
						_DbContext.Answers.Single(x => x.Text == "Меркурий"),
						_DbContext.Answers.Single(x => x.Text == "Земля")
					};
				_QuestionManagement.AddAnswer(_Question, _Answers);
				_DbContext.SaveChanges();

				Assert.DoesNotThrow(() => _QuestionManagement.SetCorrectAnswer(_Question, _DbContext.Answers.Single(x => x.Text == "Венера")));

				var _UnCorrectAnswer = _DbContext.Answers.Single(x => x.Text == "101010");
				Assert.Throws<Exception>(() => _QuestionManagement.SetCorrectAnswer(_Question, _UnCorrectAnswer));

				_Transaction.Rollback();
			}
		}

		/// <summary>
		/// Создание вопроса без ответов.
		/// </summary>
		[Test]
		public void CreateQuestionNotAnswersTest()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				DAO.Question _Question = new DAO.Question() { Text = "wtf?" };

				Assert.DoesNotThrow(() => _QuestionManagement.CreateQuestion(_Question));
				_DbContext.SaveChanges();
				Assert.True(_DbContext.Questions.Where(x => x.Text == _Question.Text).Count() == 1);

				_Transaction.Rollback();
			}
		}

		/// <summary>
		/// Создание вопроса с ответами.
		/// </summary
		[Test]
		public void CreateQuestionAnswersTest()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				// Создаем вопрос.
				DAO.Question _Question = new DAO.Question() { Text = "CreateQuestionAnswersTest?" };
				_QuestionManagement.CreateQuestion(_Question);
				_DbContext.SaveChanges();

				// Получаем сущность из БД - если не получить, то EF подумает, что надо создать новую.
				_Question = _DbContext.Questions.Include("Answers").Single(x => x.Text == _Question.Text);

				// Выбираем ответы для заполнения.
				DAO.Answer[] _Answers = new DAO.Answer[]{
						_DbContext.Answers.Single(x => x.Text == "Венера"),
						_DbContext.Answers.Single(x => x.Text == "Меркурий"),
						_DbContext.Answers.Single(x => x.Text == "Земля")
					};
				_QuestionManagement.AddAnswer(_Question, _Answers);
				_DbContext.SaveChanges();

				Assert.True(_Question.Answers.Count() == 3);

				_Transaction.Rollback();
			}
		}
	}
}