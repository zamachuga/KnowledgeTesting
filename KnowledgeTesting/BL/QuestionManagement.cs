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
			if ((Question.Answers.Count() >= 3)) throw new Exception("Вопрос может содержать не более 3 вариантов ответа.");

			DAO.QuestionAnswers _QuestionAnswers = new DAO.QuestionAnswers() { 
				AnswerId = Answer.Id, 
				QuestionId = Question.Id, 
				IsCorrect = false };

			_DbContext.QuestionAnswers.Add(_QuestionAnswers);
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
			DAO.QuestionAnswers _Answer = _DbContext.QuestionAnswers.Find(Question.Id, Answer.Id);
			DAO.QuestionAnswers _CurrentCorrectAnswer = _DbContext.QuestionAnswers.SingleOrDefault(x => x.QuestionId == Question.Id & x.IsCorrect);

			if (_Answer == null) throw new Exception("Правильный ответ должен содержаться в вопросе.");

			if (_CurrentCorrectAnswer != null)
			{
				if (_CurrentCorrectAnswer.AnswerId == Answer.Id) return;
				else _CurrentCorrectAnswer.IsCorrect = false;
			}

			_Answer.IsCorrect = true;
		}

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		public void CreateQuestion(DAO.Question Question)
		{
			if (IsExist(Question)) return;

			_DbContext.Questions.Add(Question);
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
	}
}