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
		public void CheckInstalledDbTest()
		{
			ClassDbPgSqlContext _ClassDbPgSqlContext = new ClassDbPgSqlContext();

		}
	}
}
