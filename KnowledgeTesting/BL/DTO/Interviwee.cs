using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Тестируемый.
	/// </summary>
	public class Interviwee
	{
		[DataMember]
		public int Id { get; set; }
		/// <summary>
		/// Фамилия.
		/// </summary>
		[DataMember]
		public string LastName { get; set; }
		/// <summary>
		/// Имя.
		/// </summary>
		[DataMember]
		public string FirstName { get; set; }
		/// <summary>
		/// Отчетство.
		/// </summary>
		[DataMember]
		public string SecondName { get; set; }
	}
}