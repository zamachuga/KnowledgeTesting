using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL.DB.PgSql;
using System.Data.Entity;
using System.Linq;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class DbPgSqlContextTests
	{
		[Test]
		public void InstanceTest() {
			ClassDbPgSqlContext _ClassDbPgSqlContext = new ClassDbPgSqlContext();
		}
	}
}
