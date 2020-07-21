using KnowledgeTesting.BL.DAO;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.BL.DB.PgSql
{
	/// <summary>
	/// Контекст работы с БД PostgreSql.
	/// </summary>
	public class DbPgSqlContext : DbContext
	{
		private static DbPgSqlContext _DbContext = new DbPgSqlContext();
		public string Guid { get; private set; }

		/// <summary>
		/// Ответы.
		/// </summary>
		public DbSet<DAO.Answer> Answers { get; set; }
		/// <summary>
		/// Вопросы.
		/// </summary>
		public DbSet<DAO.Question> Questions { get; set; }
		/// <summary>
		/// Ответы на вопрос.
		/// </summary>
		public DbSet<DAO.QuestionAnswers> QuestionAnswers { get; set; }
		//public DbSet<DAO.Test> Tests { get; set; }
		//public DbSet<DAO.QuestionAnswer> QuestionAnswers { get; set; }
		//public DbSet<DAO.TestQuestion> TestQuestions { get; set; }

		private DbPgSqlContext() : base("NpgsqlConnectionString") {
			Guid = System.Guid.NewGuid().ToString();
		}

		public static DbPgSqlContext Instance()
		{
			return _DbContext;
		}

		/// <summary>
		/// Ручное определение связей между сущностями.
		/// </summary>
		/// <param name="modelBuilder">Конструктор моделей в БД.</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<QuestionAnswers>()
				.HasKey(k => new { k.QuestionId, k.AnswerId });
			modelBuilder.Entity<QuestionAnswers>()
				.HasRequired(x => x.Answer)
				.WithMany(x => x.Questions)
				.HasForeignKey(x => x.AnswerId);
			modelBuilder.Entity<QuestionAnswers>()
				.HasRequired(x => x.Question)
				.WithMany(x => x.Answers)
				.HasForeignKey(x => x.QuestionId);
		}
	}
}