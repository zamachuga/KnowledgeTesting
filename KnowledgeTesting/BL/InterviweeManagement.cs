using KnowledgeTesting.BL.DB.PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестируемыми.
	/// </summary>
	public class InterviweeManagement
	{
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		public void CreateInterviwee(DAO.Interviwee Interviwee)
		{
			if (string.IsNullOrEmpty(Interviwee.FirstName)) throw new Exception("Пустое имя.");
			if (string.IsNullOrEmpty(Interviwee.LasName)) throw new Exception("Пустая фамилия.");
			if (string.IsNullOrEmpty(Interviwee.SecondName)) throw new Exception("Пустое отчество.");
			if (IsExist(Interviwee)) return;

			_DbContext.Interviwees.Add(Interviwee);
		}

		/// <summary>
		/// Получить по названию.
		/// </summary>
		public DAO.Interviwee GetInterviwee(string LasName, string FirstName, string SecondName)
		{
			var _Test = _DbContext.Interviwees.Where(x =>
				x.LasName.ToLower().Replace(" ", "") == LasName.ToLower().Replace(" ", "")
				&& x.FirstName.ToLower().Replace(" ", "") == FirstName.ToLower().Replace(" ", "")
				&& x.SecondName.ToLower().Replace(" ", "") == SecondName.ToLower().Replace(" ", "")
			).FirstOrDefault();

			return _Test;
		}

		/// <summary>
		/// Получить по коду.
		/// </summary>
		public DAO.Interviwee GetInterviwee(int id)
		{
			var _Interviwees = _DbContext.Interviwees.Find(id);
			return _Interviwees;
		}

		/// <summary>
		/// Проверить существование теста в БД.
		/// </summary>
		private bool IsExist(DAO.Interviwee Interviwee)
		{
			DAO.Interviwee _FinKey = GetInterviwee(Interviwee.Id);
			DAO.Interviwee _FindText = GetInterviwee(Interviwee.LasName, Interviwee.FirstName, Interviwee.SecondName);

			bool _IsExist = _FinKey != null || _FindText != null;
			return _IsExist;
		}
	}
}