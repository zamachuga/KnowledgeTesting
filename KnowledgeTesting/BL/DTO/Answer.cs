using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	public class Answer
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Text { get; set; }
	}
}