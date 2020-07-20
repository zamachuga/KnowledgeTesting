using KnowledgeTesting.BL;
using DAO = KnowledgeTesting.BL.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL.DB.PgSql;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class QuestionManagementTests
	{
		QuestionManagement _QuestionManagement = new QuestionManagement();
		DbPgSqlContext _DbContext = new DbPgSqlContext();

		[Test]
		public void CreateAnswerTest()
		{
			DAO.Answer _Answer = new DAO.Answer() { Text = "wtf?" };

			Assert.DoesNotThrow(() => _QuestionManagement.CreateAnswer(_Answer));
			Assert.DoesNotThrow(() => _QuestionManagement.CreateAnswer(_Answer));
			// Исключаем повторное добавление.
			Assert.True(_DbContext.Answers.Where(x => x.Text == "wtf?").Count() == 1);
		}

		[Test]
		public void GetAnswerTest()
		{
			DAO.Answer _Answer = _QuestionManagement.GetAnswer(5);

			Assert.True(_Answer.Id == 5);
		}
	}
}
