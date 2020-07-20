using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Linq;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.BL.DB.PgSql
{
	/// <summary>
	/// Контекст работы с БД PostgreSql.
	/// </summary>
	public class ClassDbPgSqlContext : DbContext
	{
		public DbSet<DAO.Answer> Answers { get; set; }
		public DbSet<DAO.Question> Questions { get; set; }
		//public DbSet<DAO.Test> Tests { get; set; }
		//public DbSet<DAO.QuestionAnswer> QuestionAnswers { get; set; }
		//public DbSet<DAO.TestQuestion> TestQuestions { get; set; }

		public ClassDbPgSqlContext() : base("NpgsqlConnectionString") { }

		/// <summary>
		/// Ручное определение связей между сущностями.
		/// </summary>
		/// <param name="modelBuilder">Конструктор моделей в БД.</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DAO.Question>()
				// EF6 почему-то решил - не надо 3ю таблицу для связи вопрос-ответы.
				.HasMany(x => x.Answers)
				.WithMany(x=>x.Questions)
				.Map(m => {
					m.ToTable("QuestionAnswers");
				});
		}
	}
}