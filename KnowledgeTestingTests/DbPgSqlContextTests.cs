using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System.Linq;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class DbPgSqlContextTests
	{
		DbPgSqlContext _DbContext = new DbPgSqlContext();

		[Test(Description = "Тест проверяет работоспособность Select к таблице. Были преценденты.")]
		public void SelectCount0Records()
		{
			var _Answers = _DbContext.Answers.Where(x => x.Id == 0);
			var _Questions = _DbContext.Questions.Where(x => x.Id == 0);

			Assert.True(_Answers.Count() == 0);
			Assert.True(_Questions.Count() == 0);
		}
	}
}
