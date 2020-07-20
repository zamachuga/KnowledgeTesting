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
		/// Создать вопрос.
		/// </summary>
		/// <param name="Text">Текст вопроса.</param>
		public void CreateAnswer(DAO.Answer Answer)
		{
			if (IsExist(Answer)) return;

			_DbContext.Answers.Add(Answer);
			_DbContext.SaveChanges();
		}

		public DAO.Answer GetAnswer(int Id)
		{
			return _DbContext.Answers.Find(Id);
		}

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

		private bool IsExist(DAO.Answer Answer)
		{
			DAO.Answer _FinKey = _DbContext.Answers.Find(Answer.Id);
			int _FindText = _DbContext.Answers.Where(x => x.Text.ToLower().Replace(" ", "") == Answer.Text.ToLower().Replace(" ", "")).Count();

			bool _IsExist = _FinKey != null || _FindText > 0;
			return _IsExist;
		}
	}
}