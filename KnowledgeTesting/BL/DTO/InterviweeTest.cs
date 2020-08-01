using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Прохождение теста.
	/// </summary>
	public class InterviweeTest
	{
		public int Id { get; set; }

		public int InterviweeId { get; set; }

		public int TestId { get; set; }

		public bool IsComplete { get; set; }

		public string ProgressText { get; set; }

		public Question CurrentQuestion { get; set; }
	}
}