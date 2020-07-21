using KnowledgeTesting.BL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class TestManagementTests
	{
		TestManagement _TestManagement = new TestManagement();
		KnowledgeTesting.BL.DB.PgSql.DbPgSqlContext _DbContext = KnowledgeTesting.BL.DB.PgSql.DbPgSqlContext.Instance();

		[Test]
		public void CreateTest()
		{
			using (var _Transaction = _DbContext.Database.BeginTransaction())
			{
				DAO.Test _Test = new DAO.Test() { Name = "CreateTest", Description = "Descr" };

				Assert.DoesNotThrow(() => _TestManagement.CreateTest(_Test));
				_DbContext.SaveChanges();

				var _FindTest = _DbContext.Tests.Where(x => x.Name == _Test.Name).SingleOrDefault();
				Assert.True(_FindTest != null);

				_Transaction.Rollback();
			}
		}
	}
}