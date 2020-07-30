using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Прохождение тестов.
	/// </summary>
	public class InterviweeTests
	{
		public InterviweeTests()
		{
			TestingResults = new List<TestingResult>();
		}

		[DataMember]
		public int Id { get; set; }
		
		[DataMember]
		public int InterviweeId { get; set; }
		
		[JsonIgnore]
		public Interviwee Interviwee { get; set; }
		
		[DataMember]
		public int TestId { get; set; }

		[JsonIgnore]
		public Test Test { get; set; }
		
		[DataMember]
		public bool IsComplete { get; set; }
		
		/// <summary>
		/// Результаты тестирования по прохождению теста.
		/// </summary>
		[JsonIgnore]
		public List<TestingResult> TestingResults { get; set; }
	}
}