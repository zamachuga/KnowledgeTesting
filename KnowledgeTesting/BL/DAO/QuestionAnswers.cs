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
		public int Id { get; set; }
		public Question Question { get; set; }
		public Answer Answer { get; set; }
		/// <summary>
		/// True - правильный ответ на вопрос.
		/// </summary>
		public bool IsCorrect { get; set; }
	}
}