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
		DB.PgSql.DbPgSqlContext _DbContext = DB.PgSql.DbPgSqlContext.Instance();

		/// <summary>
		/// Добавить вариант ответа в вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <param name="Answer"></param>
		public void AddAnswer(DAO.Question Question, DAO.Answer Answer)
		{
			if (Question.Answers.Where(x => x.AnswerId == Answer.Id).Count() == 1) return;
			if ((Question.Answers.Count() >= 3)) throw new Exception("Вопрос может содержать не более 3 вариантов ответа.");

			DAO.QuestionAnswers _QuestionAnswers = new DAO.QuestionAnswers()
			{
				AnswerId = Answer.Id,
				QuestionId = Question.Id,
				IsCorrect = false
			};

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
		public void CreateQuestion(params DAO.Question[] Questions)
		{
			foreach (var _Question in Questions)
			{
				CreateQuestion(_Question);
			}
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
		/// Получить вопрос.
		/// </summary>
		/// <param name="Text">Название.</param>
		/// <returns></returns>
		public DAO.Question GetQuestion(string Text)
		{
			var _Question = _DbContext.Questions.Where(x => x.Text == Text).FirstOrDefault();
			return _Question;
		}

		/// <summary>
		/// Найти вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <returns></returns>
		private bool IsExist(DAO.Question Question)
		{
			DAO.Question _FinKey = _DbContext.Questions.Where(x => x.Id == Question.Id).FirstOrDefault();
			int _FindText = _DbContext.Questions.Where(x => x.Text.ToLower().Replace(" ", "") == Question.Text.ToLower().Replace(" ", "")).Count();

			bool _IsExist = (_FinKey != null && _FinKey.Id > 0) || _FindText > 0;
			return _IsExist;
		}
	}
}