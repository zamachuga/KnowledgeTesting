using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Ответ.
	/// </summary>
	public class Answer
	{
		public Answer()
		{
			Questions = new List<QuestionAnswers>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		/// <summary>
		/// Вопросы в которых участвует ответ.
		/// </summary>
		public List<QuestionAnswers> Questions { get; set; }
		/// <summary>
		/// Результаты тестов в которых участвовал ответ.
		/// </summary>
		public List<TestingResult> TestingResults { get; set; }
	}
}