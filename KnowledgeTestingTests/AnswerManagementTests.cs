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
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		[Test]
		public void CreateAnswerTest()
		{
			using (var _Transaction =_DbContext.Database.BeginTransaction())
			{
				DAO.Answer _Answer = new DAO.Answer() { Text = "wtf?" };

				Assert.DoesNotThrow(() => _AnswerManagement.CreateAnswer(_Answer));
				Assert.DoesNotThrow(() => _AnswerManagement.CreateAnswer(_Answer));
				_DbContext.SaveChanges();
				// Исключаем повторное добавление.
				var _Count = _DbContext.Answers.Where(x => x.Text == _Answer.Text).Count();
				Assert.True(_Count == 1);

				_Transaction.Rollback();
			}
		}

		[Test]
		public void GetAnswerTest()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				DAO.Answer _Answer = _AnswerManagement.GetAnswer(5);

				Assert.True(_Answer.Id == 5);

				_Transaction.Rollback();
			}
		}
	}
}
