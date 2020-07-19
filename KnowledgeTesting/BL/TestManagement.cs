using KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестами.
	/// </summary>
	public class TestManagement
	{
		public Test CreateTest()
		{
			DB.PgSql.ClassDbPgSqlContext _DbContext = new DB.PgSql.ClassDbPgSqlContext();

			return _DbContext.Tests.Create();
		}

		public Test ReadTest(int Id)
		{
			return null;
		}

		public void UpdateTest(DTO.Test Test)
		{
			if (Test.Id == 0) return;
		}

		public void DeleteTest(int Id)
		{
			if (Id == 0) return;
		}
	}
}