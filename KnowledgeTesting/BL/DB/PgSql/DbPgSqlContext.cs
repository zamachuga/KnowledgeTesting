using KnowledgeTesting.BL.DAO;
using System.Data.Entity;

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
		public DbSet<Answer> Answers { get; set; }
		/// <summary>
		/// Вопросы.
		/// </summary>
		public DbSet<Question> Questions { get; set; }
		/// <summary>
		/// Ответы на вопрос.
		/// </summary>
		public DbSet<QuestionAnswers> QuestionAnswers { get; set; }
		/// <summary>
		/// Тесты.
		/// </summary>
		public DbSet<Test> Tests { get; set; }
		/// <summary>
		/// Вопросы тестов.
		/// </summary>
		public DbSet<TestQuestions> TestQuestions { get; set; }
		/// <summary>
		/// Прохождение тестов.
		/// </summary>
		public DbSet<InterviweeTests> InterviweeTests { get; set; }
		/// <summary>
		/// Результаты прохождения тестов.
		/// </summary>
		public DbSet<TestingResult> TestingResults { get; set; }
		/// <summary>
		/// Тестируемые.
		/// </summary>
		public DbSet<Interviwee> Interviwees { get; set; }

		// В режиме отладки конструктор публичный ради создания миграции БД.
#if DEBUG
		public DbPgSqlContext() : base("NpgsqlConnectionString")
		{
			Guid = System.Guid.NewGuid().ToString();
		}
#else
		private DbPgSqlContext() : base("NpgsqlConnectionString") {
			Guid = System.Guid.NewGuid().ToString();
		}
#endif

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

			modelBuilder.Entity<TestQuestions>()
				.HasKey(k => new { k.TestId, k.QuestionId });
			modelBuilder.Entity<TestQuestions>()
				.HasRequired(x => x.Test)
				.WithMany(x => x.Questions)
				.HasForeignKey(x => x.TestId);
			modelBuilder.Entity<TestQuestions>()
				.HasRequired(x => x.Question)
				.WithMany(x => x.Tests)
				.HasForeignKey(x => x.QuestionId);

			modelBuilder.Entity<InterviweeTests>()
				.HasKey(k => k.Id);
			modelBuilder.Entity<InterviweeTests>()
				.HasRequired(x => x.Test)
				.WithMany(x => x.Interviwees)
				.HasForeignKey(x => x.TestId);
			modelBuilder.Entity<InterviweeTests>()
				.HasRequired(x => x.Interviwee)
				.WithMany(x => x.Tests)
				.HasForeignKey(x => x.InterviweeId);

			modelBuilder.Entity<TestingResult>()
				.HasKey(k => k.Id);
			modelBuilder.Entity<TestingResult>()
				.HasRequired(x => x.Question)
				.WithMany(x => x.TestingResults)
				.HasForeignKey(x => x.QuestionId);
			modelBuilder.Entity<TestingResult>()
				.HasRequired(x => x.Answer)
				.WithMany(x => x.TestingResults)
				.HasForeignKey(x => x.AnswerId);
		}
	}
}