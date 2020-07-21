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

		public void CreateInterviwee(DAO.Interviwee Interviwee) {
			if (string.IsNullOrEmpty(Interviwee.FirstName)) throw new Exception("Пустое имя.");
			if (string.IsNullOrEmpty(Interviwee.LasName)) throw new Exception("Пустая фамилия.");

			_DbContext.Interviwees.Add(Interviwee);
			_DbContext.SaveChanges();
		}
	}
}