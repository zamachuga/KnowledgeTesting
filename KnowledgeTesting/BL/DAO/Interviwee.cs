using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Тестируемый.
	/// </summary>
	public class Interviwee
	{
		public int Id { get; set; }
		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LasName { get; set; }
		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// Отчетство.
		/// </summary>
		public string SecondName { get; set; }
		/// <summary>
		/// Прохождение тестов.
		/// </summary>
		public virtual List<InterviweeTests> Tests { get; set; }
	}
}