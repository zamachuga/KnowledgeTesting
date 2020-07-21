using KnowledgeTesting.BL.DAO;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Linq;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.BL.DB.PgSql
{
	/// <summary>
	/// Контекст работы с БД PostgreSql.
	/// </summary>
	public class DbPgSqlContext : DbContext
	{
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

		public DbPgSqlContext() : base("NpgsqlConnectionString") { }

		/// <summary>
		/// Ручное определение связей между сущностями.
		/// </summary>
		/// <param name="modelBuilder">Конструктор моделей в БД.</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DAO.QuestionAnswers>()
				.HasKey(k => new { k.QuestionId, k.AnswerId });
			modelBuilder.Entity<DAO.QuestionAnswers>()
				.HasRequired(x => x.Answer)
				.WithMany(x => x.QuestionAnswers)
				.HasForeignKey(x => x.AnswerId);
			modelBuilder.Entity<DAO.QuestionAnswers>()
				.HasRequired(x => x.Question)
				.WithMany(x => x.QuestionAnswers)
				.HasForeignKey(x => x.QuestionId);
		}
	}
}