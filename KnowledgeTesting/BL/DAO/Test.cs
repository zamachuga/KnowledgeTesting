using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Тест.
	/// </summary>
	[DataContract]
	public class Test
	{
		public Test()
		{
			Questions = new List<TestQuestions>();
			Interviwees = new List<InterviweeTests>();
		}

		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Description { get; set; }
		/// <summary>
		/// Вопросы в тесте.
		/// </summary>
		[JsonIgnore]
		public virtual List<TestQuestions> Questions { get; set; }
		/// <summary>
		/// Прохождения теста.
		/// </summary>
		[JsonIgnore]
		public virtual List<InterviweeTests> Interviwees { get; set; }
	}
}