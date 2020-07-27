using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопросы теста.
	/// </summary>
	[DataContract]
	public class TestQuestions
	{
		[DataMember]
		public int TestId { get; set; }		
		public virtual Test Test { get; set; }
		[DataMember]
		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }
	}
}