using KnowledgeTesting.BL;
using DAO = KnowledgeTesting.BL.DAO;
using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class TestingManagementTests
	{
		TestingManagement _TestingManagement = new TestingManagement();
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		[Test]
		public void StartTest()
		{
			using ( var _Trns = _DbContext.Database.BeginTransaction())
			{
				DAO.Interviwee _Interviwee = new DAO.Interviwee() { FirstName = "sdad", LasName = "adasd"};
				_Interviwee = _DbContext.Interviwees.Add(_Interviwee);
				DAO.Test _Test = new DAO.Test() { Name = "sdasdasd"};
				_Test = _DbContext.Tests.Add(_Test);
				_DbContext.SaveChanges();

				DAO.InterviweeTests _Result = _TestingManagement.StartTest(_Interviwee, _Test);
				_DbContext.SaveChanges();

				Assert.True(_Result.Id > 0);

				_Trns.Rollback();
			}
		}
	}
}