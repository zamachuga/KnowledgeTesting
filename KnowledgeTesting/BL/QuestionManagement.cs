using System;
using System.Collections.Generic;
using System.Linq;

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
			//if ((Question.Answers.Count() >= 3)) throw new Exception("Вопрос может содержать не более 3 вариантов ответа.");

			//Question.Answers.Add(Answer);
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Добавить вариант ответа в вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <param name="Answer"></param>
		public void AddAnswer(DAO.Question Question, params DAO.Answer[] Answer)
		{
			foreach (var item in Answer)
			{
				AddAnswer(Question, item);
			};
		}

		/// <summary>
		/// Установить правильный ответ на вопрос.
		/// </summary>
		public void SetCorrectAnswer(DAO.Question Question, DAO.Answer Answer)
		{
			//if (!Question.Answers.Contains(Answer)) throw new Exception("Правильный ответ должен быть одним из вариантов ответов.");

			//Question.Answer = Answer;
			//Question.AnswerId = Answer.Id;
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		public void CreateQuestion(DAO.Question Question)
		{
			if (IsExist(Question)) return;
			CheckDataQuestion(Question);

			//Question.Answers = new List<DAO.Answer>();
			_DbContext.Questions.Add(Question);
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Найти вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <returns></returns>
		private bool IsExist(DAO.Question Question)
		{
			DAO.Question _FinKey = _DbContext.Questions.Find(Question.Id);
			int _FindText = _DbContext.Questions.Where(x => x.Text.ToLower().Replace(" ", "") == Question.Text.ToLower().Replace(" ", "")).Count();

			bool _IsExist = _FinKey != null || _FindText > 0;
			return _IsExist;
		}

		/// <summary>
		/// Проверить содержимое.
		/// </summary>
		/// <param name="Question"></param>
		/// <returns></returns>
		private void CheckDataQuestion(DAO.Question Question)
		{
			//if (Question.Answers.Count > 0 & Question.Answer == null) 
			//throw new Exception("При наличии ответов в вопросе, необходимо указать правильный ответ.");
		}
	}
}