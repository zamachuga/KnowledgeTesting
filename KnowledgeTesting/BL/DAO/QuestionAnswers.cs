using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Ответы на вопрос.
	/// </summary>
	public class QuestionAnswers
	{
		[DataMember]
		public int QuestionId { get; set; }
		[JsonIgnore]
		public virtual Question Question { get; set; }
		[DataMember]
		public int AnswerId { get; set; }
		[DataMember]
		public virtual Answer Answer { get; set; }
		[DataMember]
		public bool IsCorrect { get; set; }
	}
}