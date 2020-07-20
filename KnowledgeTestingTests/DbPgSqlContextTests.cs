using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System.Linq;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class DbPgSqlContextTests
	{
		ClassDbPgSqlContext _DbContext = new ClassDbPgSqlContext();

		[Test]
		public void SelectCount0Records()
		{
			Assert.DoesNotThrow(()=>
				_DbContext.Tests.Select(x => x.Name.ToLower().Replace(" ", "") == "---TestName".ToLower().Replace(" ", "")).Count()
			);
		}
	}
}
