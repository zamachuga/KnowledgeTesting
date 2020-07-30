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
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int InterviweeId { get; set; }

		[DataMember]
		public int TestId { get; set; }

		[DataMember]
		public bool IsComplete { get; set; }

		[DataMember]
		public Question CurrentQuestion { get; set; }
	}
}