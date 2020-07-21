﻿using Microsoft.Ajax.Utilities;
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