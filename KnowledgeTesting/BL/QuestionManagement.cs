using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление вопросами.
	/// </summary>
	public class QuestionManagement
	{
		DB.PgSql.DbPgSqlContext _DbContext = new DB.PgSql.DbPgSqlContext();

		/// <summary>
		/// Добавить вариант ответа в вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <param name="Answer"></param>
		public void AddAnswer(DAO.Question Question, DAO.Answer Answer)
		{
			if ((Question.Answers.Count() >= 3)) throw new Exception("Вопрос может содержать не более 3 вариантов ответа.");

			Question.Answers.Add(Answer);
		}

		/// <summary>
		/// Установить правильный ответ на вопрос.
		/// </summary>
		public void SetCorrectAnswer(DAO.Question Question, DAO.Answer Answer)
		{
			if (!Question.Answers.Contains(Answer)) throw new Exception("Правильный ответ должен быть одним из вариантов ответов.");

			Question.CorrectAnswer = Answer;
		}
	}
}