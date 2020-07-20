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

		[Test]
		public void CreateQuestionNotAnswersTest()
		{
			DAO.Question _Question = new DAO.Question() { Text = "wtf?" };

			Assert.DoesNotThrow(() => _QuestionManagement.CreateQuestion(_Question));
			Assert.True(_DbContext.Questions.Where(x => x.Text == _Question.Text).Count() == 1);
		}
	}
}
