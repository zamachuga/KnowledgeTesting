using KnowledgeTesting.BL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление вопросами.
	/// </summary>
	public class AnswerManagement
	{
		DB.PgSql.DbPgSqlContext _DbContext = DB.PgSql.DbPgSqlContext.Instance();

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		/// <param name="Text">Текст вопроса.</param>
		public void CreateAnswer(DAO.Answer Answer)
		{
			if (Answer.Text.Replace(" ", "").Length <= 0) return;
			if (IsExist(Answer)) return;

			_DbContext.Answers.Add(Answer);
			_DbContext.SaveChanges();
		}

		public DAO.Answer GetAnswer(int Id)
		{
			return _DbContext.Answers.Find(Id);
		}

		public DAO.Answer GetAnswer(string Text)
		{
			var _Answer = _DbContext.Answers.Where(x => x.Text.ToLower().Replace(" ", "") == Text.ToLower().Replace(" ", "")).FirstOrDefault();
			return _Answer;
		}

		/// <summary>
		/// Поиск ответа в БД.
		/// </summary>
		/// <param name="Answer"></param>
		/// <returns></returns>
		/// 
		private bool IsExist(DAO.Answer Answer)
		{
			DAO.Answer _FinKey = GetAnswer(Answer.Id);
			DAO.Answer _FindText = GetAnswer(Answer.Text);

			bool _IsExist = _FinKey != null || _FindText != null;
			return _IsExist;
		}

		/// <summary>
		/// Получить все ответы.
		/// </summary>
		/// <returns></returns>
		internal Answer[] GetAllAnswers()
		{
			return _DbContext.Answers.ToArray();
		}
	}
}