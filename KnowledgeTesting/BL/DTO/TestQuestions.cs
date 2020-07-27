using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Вопросы теста.
	/// </summary>
	public class TestQuestions
	{
		public int TestId { get; set; }
		public int QuestionId { get; set; }
	}
}