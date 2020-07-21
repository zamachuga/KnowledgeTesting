using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Ответы на вопрос.
	/// </summary>
	public class QuestionAnswers
	{
		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }
		public int AnswerId { get; set; }
		public virtual Answer Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}