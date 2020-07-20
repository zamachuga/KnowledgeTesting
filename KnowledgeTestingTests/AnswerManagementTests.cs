using KnowledgeTesting.BL;
using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class AnswerManagementTests
	{
		AnswerManagement _AnswerManagement = new AnswerManagement();
		DbPgSqlContext _DbContext = new DbPgSqlContext();

		[Test]
		public void CreateAnswerTest()
		{
			DAO.Answer _Answer = new DAO.Answer() { Text = "wtf?" };

			Assert.DoesNotThrow(() => _AnswerManagement.CreateAnswer(_Answer));
			Assert.DoesNotThrow(() => _AnswerManagement.CreateAnswer(_Answer));
			// Исключаем повторное добавление.
			Assert.True(_DbContext.Answers.Where(x => x.Text == "wtf?").Count() == 1);
		}

		[Test]
		public void GetAnswerTest()
		{
			DAO.Answer _Answer = _AnswerManagement.GetAnswer(5);

			Assert.True(_Answer.Id == 5);
		}
	}
}
