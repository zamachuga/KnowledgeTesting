﻿using System.Data.Entity;

namespace KnowledgeTesting.BL.DB.PgSql
{
	public class ClassDbPgSqlContext: DbContext
	{
		public DbSet<DAO.ClassAnswer> Answers { get; set; }
		public DbSet<DAO.ClassInterviewee> Interviewees { get; set; }
		public DbSet<DAO.ClassQuestion> Questions { get; set; }
		public DbSet<DAO.ClassTest> Tests { get; set; }
		public DbSet<DAO.ClassTesting> Testings { get; set; }
	}
}