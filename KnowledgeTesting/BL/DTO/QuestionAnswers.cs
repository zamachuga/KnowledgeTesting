using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Ответы на вопрос.
	/// </summary>
	public class QuestionAnswers
	{
		public int QuestionId { get; set; }
		public int AnswerId { get; set; }
		public string AnswerText { get; set; }
		public bool IsCorrect { get; set; }
	}
}