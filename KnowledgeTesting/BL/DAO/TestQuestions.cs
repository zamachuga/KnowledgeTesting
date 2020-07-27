using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопросы теста.
	/// </summary>
	public class TestQuestions
	{
		public int TestId { get; set; }
		public Test Test { get; set; }
		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }
	}
}