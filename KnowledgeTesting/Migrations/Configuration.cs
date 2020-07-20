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

			//context.Answers.AddOrUpdate(x => x.Text, GenerateAnswers());
			//context.SaveChanges();

			//if (context.Questions.Count() == 0)
			//{
			//	context.Questions.AddOrUpdate(x => x.Text, GenerateQuestions(context));
			//	context.SaveChanges();
			//}
		}

		//private DAO.Answer[] GenerateAnswers()
		//{
		//	DAO.Answer[] _Data = new DAO.Answer[]
		//	{
		//		new DAO.Answer(){Text = "Венера"},
		//		new DAO.Answer(){Text = "Меркурий"},
		//		new DAO.Answer(){Text = "Земля"},

		//		new DAO.Answer(){Text = "111000"},
		//		new DAO.Answer(){Text = "101010"},
		//		new DAO.Answer(){Text = "11011"},

		//		new DAO.Answer(){Text = "7 млрд."},
		//		new DAO.Answer(){Text = "10 млрд."},
		//		new DAO.Answer(){Text = "5 млрд."},

		//		new DAO.Answer(){Text = "Лермонтов"},
		//		new DAO.Answer(){Text = "Пушкин"},
		//		new DAO.Answer(){Text = "Некрасов"},

		//		new DAO.Answer(){Text = "6"},
		//		new DAO.Answer(){Text = "8"},
		//		new DAO.Answer(){Text = "12"}
		//	};

		//	return _Data;
		//}

		//private DAO.Question[] GenerateQuestions(BL.DB.PgSql.ClassDbPgSqlContext context)
		//{
		//	DAO.Question[] _Data = new DAO.Question[] {
		//		new DAO.Question(){
		//			Text = "Вторая планета Солнечной системы?",
		//			Answers = new List<DAO.Answer>(){
		//				context.Answers.First(x => x.Text == "Венера"),
		//				context.Answers.First(x => x.Text == "Меркурий"),
		//				context.Answers.First(x => x.Text == "Земля")
		//			}
		//		},
		//		new DAO.Question(){
		//			Text = "Число 27 в двоичной системе исчисления?",
		//			Answers = new List<DAO.Answer>(){
		//				context.Answers.First(x=>x.Text == "111000"),
		//				context.Answers.First(x=>x.Text == "101010"),
		//				context.Answers.First(x=>x.Text == "11011")
		//			}
		//		},
		//		new DAO.Question(){
		//			Text = "Примерное количество людей на Земле?",
		//			Answers = new List<DAO.Answer>(){
		//				context.Answers.First(x=>x.Text == "7 млрд."),
		//				context.Answers.First(x=>x.Text == "10 млрд."),
		//				context.Answers.First(x=>x.Text == "5 млрд.")
		//			}
		//		},
		//		new DAO.Question(){
		//			Text = "Кто написал «Сказка о царе Салтане»?",
		//			Answers = new List<DAO.Answer>(){
		//				context.Answers.First(x=>x.Text == "Лермонтов"),
		//				context.Answers.First(x=>x.Text == "Пушкин"),
		//				context.Answers.First(x=>x.Text == "Некрасов")
		//			}
		//		},
		//		new DAO.Question(){
		//			Text = "Сколько граней у куба?",
		//			Answers = new List<DAO.Answer>(){
		//				context.Answers.First(x=>x.Text == "6"),
		//				context.Answers.First(x=>x.Text == "8"),
		//				context.Answers.First(x=>x.Text == "12")
		//			}
		//		}
		//	};

		//	return _Data;
		//}
	}
}
