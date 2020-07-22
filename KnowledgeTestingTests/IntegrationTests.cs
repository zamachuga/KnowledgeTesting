using KnowledgeTesting.BL.DB.PgSql;
using DAO = KnowledgeTesting.BL.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeTesting.BL;

namespace KnowledgeTestingTests
{
	/// <summary>
	/// Интеграционное тестирование по сценариям.
	/// </summary>
	[TestFixture]
	public class IntegrationTests
	{
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		[Test]
		public void CreateQuestions()
		{
			QuestionManagement _QuestionManagement = new QuestionManagement();

			DAO.Question[] _Questions = new DAO.Question[] {
				new DAO.Question(){ Text = "Вторая планета Солнечной системы?"},
				new DAO.Question(){ Text = "Число 27 в двоичной системе исчисления?"},
				new DAO.Question(){ Text = "Примерное количество людей на Земле?"},
				new DAO.Question(){ Text = "Кто написал «Сказка о царе Салтане»?"},
				new DAO.Question(){ Text = "Сколько граней у куба?"}
			};

			_QuestionManagement.CreateQuestion(_Questions);
			_DbContext.SaveChanges();

			var _Result = _DbContext.Questions.Where(x => x.Text == "Число 27 в двоичной системе исчисления?").FirstOrDefault();

			Assert.True(_Result != null & _Result.Id > 0);
		}
	}
}

