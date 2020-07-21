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
			// Модель создаваемого вопроса.
			DAO.Question _Question = new DAO.Question() { Text = "CreateQuestionAnswersTest?" };

			// Удаляем если вопрос существует.
			DAO.Question _RemoveQuestion = _DbContext.Questions.FirstOrDefault(x => x.Text == _Question.Text);
			if (_RemoveQuestion != null)
				_DbContext.Questions.Remove(_RemoveQuestion);

			// Создаем вопрос.
			_QuestionManagement.CreateQuestion(_Question);
			// Получаем сущность из БД - если не получить, то EF подумает, что надо создать новую.
			_Question = _DbContext.Questions.Include("Answers").Single(x => x.Text == _Question.Text);

			DAO.Answer[] _Answers = new DAO.Answer[]{
						_DbContext.Answers.Single(x => x.Text == "Венера"),
						_DbContext.Answers.Single(x => x.Text == "Меркурий"),
						_DbContext.Answers.Single(x => x.Text == "Земля")
					};
			_QuestionManagement.AddAnswer(_Question, _Answers);

			// Мелкие проверки на всякий случай.
			Assert.True(_DbContext.Questions.Where(x => x.Text == _Question.Text).Count() == 1);
			Assert.True(_DbContext.Answers.Where(x => x.Text == "Венера").Count() == 1);
		}
	}
}