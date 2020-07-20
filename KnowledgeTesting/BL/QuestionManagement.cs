﻿using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

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

		private bool IsExist(DAO.Answer Answer)
		{
			DAO.Answer _FinKey = _DbContext.Answers.Find(Answer.Id);
			int _FindText = _DbContext.Answers.Where(x => x.Text.ToLower().Replace(" ","") == Answer.Text.ToLower().Replace(" ", "")).Count();

			bool _IsExist = _FinKey != null || _FindText > 0;
			return _IsExist;
		}
	}
}