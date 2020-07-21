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
			if (IsExist(Answer)) return;

			_DbContext.Answers.Add(Answer);
		}

		public DAO.Answer GetAnswer(int Id)
		{
			return _DbContext.Answers.Find(Id);
		}

		/// <summary>
		/// Поиск ответа в БД.
		/// </summary>
		/// <param name="Answer"></param>
		/// <returns></returns>
		private bool IsExist(DAO.Answer Answer)
		{
			DAO.Answer _FinKey = _DbContext.Answers.Find(Answer.Id);
			int _FindText = _DbContext.Answers.Where(x => x.Text.ToLower().Replace(" ", "") == Answer.Text.ToLower().Replace(" ", "")).Count();

			bool _IsExist = _FinKey != null || _FindText > 0;
			return _IsExist;
		}
	}
}