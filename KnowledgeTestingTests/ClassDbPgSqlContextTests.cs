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
	class ClassDbPgSqlContextTests
	{
		[Test]
		public void InstanceTest() {
			ClassDbPgSqlContext _ClassDbPgSqlContext = new ClassDbPgSqlContext();
		}

		[Test]
		public void CheckInstalledDbTest()
		{
			ClassDbPgSqlContext _ClassDbPgSqlContext = new ClassDbPgSqlContext();
			_ClassDbPgSqlContext.CheckInstalledDb();
		}
	}
}
