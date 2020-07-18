using System.Data.Entity;
using System.Linq;

namespace KnowledgeTesting.BL.DB.PgSql
{
	public class ClassDbPgSqlContext: DbContext
	{
		public DbSet<DAO.ClassAnswer> Answers { get; set; }
		public DbSet<DAO.ClassInterviewee> Interviewees { get; set; }
		public DbSet<DAO.ClassQuestion> Questions { get; set; }
		public DbSet<DAO.ClassTest> Tests { get; set; }
		public DbSet<DAO.ClassTesting> Testings { get; set; }

		public ClassDbPgSqlContext() : base("NpgsqlConnectionString")
		{
		}

		/// <summary>
		/// Проверить установку базы данных.
		/// </summary>
		/// <returns></returns>
		public bool CheckInstalledDb()
		{
			var ListAnswers = Answers.ToList();
			return false;
		}
	}
}