namespace KnowledgeTesting.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using DAO = KnowledgeTesting.BL.DAO;

	internal sealed class Configuration : DbMigrationsConfiguration<BL.DB.PgSql.ClassDbPgSqlContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(BL.DB.PgSql.ClassDbPgSqlContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.

			context.Answers.AddOrUpdate(GenerateAnswers());
			context.Questions.AddOrUpdate(GenerateQuestions(context));
		}

		private DAO.ClassAnswer[] GenerateAnswers()
		{
			DAO.ClassAnswer[] _Data = new DAO.ClassAnswer[] {
				new DAO.ClassAnswer(){Id = 1, Text = "Венера"},
				new DAO.ClassAnswer(){Id = 2, Text = "Меркурий"},
				new DAO.ClassAnswer(){Id = 3, Text = "Земля"},
				new DAO.ClassAnswer(){Id = 4, Text = "111000"},
				new DAO.ClassAnswer(){Id = 5, Text = "101010"},
				new DAO.ClassAnswer(){Id = 6, Text = "11011"},
				new DAO.ClassAnswer(){Id = 7, Text = "7 млрд."},
				new DAO.ClassAnswer(){Id = 8, Text = "10 млрд."},
				new DAO.ClassAnswer(){Id = 9, Text = "5 млрд."},
				new DAO.ClassAnswer(){Id = 10, Text = "Лермонтов"},
				new DAO.ClassAnswer(){Id = 11, Text = "Пушкин"},
				new DAO.ClassAnswer(){Id = 12, Text = "Некрасов"},
				new DAO.ClassAnswer(){Id = 13, Text = "6"},
				new DAO.ClassAnswer(){Id = 14, Text = "8"},
				new DAO.ClassAnswer(){Id = 15, Text = "12"}
			};

			return _Data;
		}

		private DAO.ClassQuestion[] GenerateQuestions(BL.DB.PgSql.ClassDbPgSqlContext context)
		{
			DAO.ClassQuestion[] _Data = new DAO.ClassQuestion[] {
				new DAO.ClassQuestion(){
					Id = 1,
					Text = "Вторая планета Солнечной системы",
					Answers = new List<DAO.ClassAnswer>(){
						context.Answers.FirstOrDefault(x=> x.Id == 1),
						context.Answers.FirstOrDefault(x=> x.Id == 2),
						context.Answers.FirstOrDefault(x=> x.Id == 3)},
					CorrectAnswer = context.Answers.FirstOrDefault(x=> x.Id == 1)},
				new DAO.ClassQuestion(){
					Id = 2,
					Text = "Число 27 в двоичной системе исчисления",
					Answers = new List<DAO.ClassAnswer>(){
						context.Answers.FirstOrDefault(x=> x.Id == 4),
						context.Answers.FirstOrDefault(x=> x.Id == 5),
						context.Answers.FirstOrDefault(x=> x.Id == 6),},
					CorrectAnswer = context.Answers.FirstOrDefault(x=> x.Id == 6)},
				new DAO.ClassQuestion(){
					Id = 3,
					Text = "Примерное количество людей на Земле",
					Answers = new List<DAO.ClassAnswer>(){
						context.Answers.FirstOrDefault(x=> x.Id == 7),
						context.Answers.FirstOrDefault(x=> x.Id == 8),
						context.Answers.FirstOrDefault(x=> x.Id == 9),},
					CorrectAnswer = context.Answers.FirstOrDefault(x=> x.Id == 7)},
				new DAO.ClassQuestion(){
					Id = 4,
					Text = "Кто написал «Сказка о царе Салтане»",
					Answers = new List<DAO.ClassAnswer>(){
						context.Answers.FirstOrDefault(x=> x.Id == 10),
						context.Answers.FirstOrDefault(x=> x.Id == 11),
						context.Answers.FirstOrDefault(x=> x.Id == 12),},
					CorrectAnswer = context.Answers.FirstOrDefault(x=> x.Id == 11)},
				new DAO.ClassQuestion(){
					Id = 5,
					Text = "Сколько граней у куба?",
					Answers = new List<DAO.ClassAnswer>(){
						context.Answers.FirstOrDefault(x=> x.Id == 13),
						context.Answers.FirstOrDefault(x=> x.Id == 14),
						context.Answers.FirstOrDefault(x=> x.Id == 15),},
					CorrectAnswer = context.Answers.FirstOrDefault(x=> x.Id == 13)}
			};

			return _Data;
		}
	}
}
