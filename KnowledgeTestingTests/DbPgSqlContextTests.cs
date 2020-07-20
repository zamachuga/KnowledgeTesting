using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System.Linq;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class DbPgSqlContextTests
	{
		DbPgSqlContext _DbContext = new DbPgSqlContext();

		[Test]
		public void SelectCount0Records()
		{
			Assert.True(_DbContext.Answers.Select(x => x.Id == 0).Count() == 0);
			Assert.True(_DbContext.Questions.Select(x => x.Id == 0).Count() == 0);
		}
	}
}
