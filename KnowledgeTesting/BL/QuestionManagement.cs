using KnowledgeTesting.BL.DAO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

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
			DAO.QuestionAnswers _QuestionAnswer = _DbContext.QuestionAnswers.Find(Question.Id, Answer.Id);
			if (_QuestionAnswer == null) throw new Exception("Правильный ответ должен содержаться в вопросе.");

			DAO.QuestionAnswers _CurrentCorrectAnswer = _DbContext.QuestionAnswers.SingleOrDefault(x => x.QuestionId == Question.Id & x.IsCorrect);
			if (_CurrentCorrectAnswer != null) _CurrentCorrectAnswer.IsCorrect = false;

			_QuestionAnswer.IsCorrect = true;
			_DbContext.SaveChanges();
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
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Получить вопрос.
		/// </summary>
		/// <param name="Text">Название.</param>
		/// <returns></returns>
		public DAO.Question GetQuestion(string Text)
		{
			var _Question = _DbContext.Questions
				.Where(x => x.Text.ToLower().Replace(" ", "") == Text.ToLower().Replace(" ", ""))
				.FirstOrDefault();

			return _Question;
		}

		/// <summary>
		/// Получить вопрос по коду.
		/// </summary>
		/// <param name="QuestionId">Код вопроса.</param>
		/// <returns></returns>
		internal Question GetQuestion(int QuestionId)
		{
			DAO.Question _FinKey = _DbContext.Questions.Where(x => x.Id == QuestionId).FirstOrDefault();
			return _FinKey;
		}

		/// <summary>
		/// Найти вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <returns></returns>
		private bool IsExist(DAO.Question Question)
		{
			DAO.Question _FinKey = GetQuestion(Question.Id);
			DAO.Question _FindText = GetQuestion(Question.Text);

			bool _IsExist = _FinKey != null || _FindText != null;

			return _IsExist;
		}

		/// <summary>
		/// Получить список всех квестов.
		/// </summary>
		/// <param name="FilterName">Фильтр по наименованию.</param>
		/// <returns></returns>
		internal DAO.Question[] GetAllQuestions(string FilterName)
		{
			// TODO: настроить Like по запросу.
			// эта черхарда и тут сопротивляется.
			//NpgsqlParameter _PFiltername = new NpgsqlParameter("@FilterName", $@"%{FilterName.ToLower().Replace(' ','%')}%");
			//Question[] _Questions = _DbContext.Questions
			//	.SqlQuery("Select * From dbo.\"Questions\" q Where Lower(q.\"Text\" ) Like '@FilterName'", _PFiltername)
			//	.ToArray();
			//;

			Question[] _Questions = _DbContext.Questions.ToArray();

			return _Questions;
		}

		/// <summary>
		/// Удалить ответ из вопроса.
		/// </summary>
		/// <param name="QuestionAnswer"></param>
		internal void RemoveAnswer(DAO.QuestionAnswers QuestionAnswer)
		{
			_DbContext.QuestionAnswers.Remove(QuestionAnswer);
			_DbContext.SaveChanges();
		}

		/// <summary>
		/// Получить ответ на вопрос.
		/// (содержится в вопросе).
		/// </summary>
		/// <param name="QuestionId">Код вопроса.</param>
		/// <param name="AnswerId">Код ответа.</param>
		/// <returns></returns>
		internal QuestionAnswers GetAnswer(int QuestionId, int AnswerId)
		{
			var _QuestionAnswer = _DbContext.QuestionAnswers.Where(x => x.QuestionId == QuestionId & x.AnswerId == AnswerId).FirstOrDefault();
			return _QuestionAnswer;
		}

		/// <summary>
		/// Сохранить изменение вопроса.
		/// </summary>
		/// <param name="Question">Вопрос.</param>
		internal void SaveQuestion(DAO.Question Question)
		{
			if (_DbContext.Entry(Question).State == EntityState.Detached)
				_DbContext.Entry(Question).State = EntityState.Modified;

			_DbContext.SaveChanges();
		}
	}
}