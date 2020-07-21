using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Прохождение тестов.
	/// </summary>
	public class InterviweeTests
	{
		public int Id { get; set; }
		public int InterviweeId { get; set; }
		public Interviwee Interviwee { get; set; }
		public int TestId { get; set; }
		public Test Test { get; set; }		
		public bool IsComplete { get; set; }
	}
}