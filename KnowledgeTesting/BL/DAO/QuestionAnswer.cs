using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Ответ на вопрос.
	/// </summary>
	public class QuestionAnswer
	{
		public int Id { get; set; }
		public Question Question { get; set; }
		public Answer Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}