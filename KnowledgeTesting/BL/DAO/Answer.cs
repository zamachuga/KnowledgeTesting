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
			Questions = new List<Question>();
			//CorrectToQuestions = new List<Question>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		/// <summary>
		/// Вопросы в которых участвует ответ.
		/// </summary>
		public ICollection<Question> Questions { get; set; }
		/// <summary>
		/// Вопросы для которых ответ правильный.
		/// </summary>
		//public ICollection<Question> CorrectToQuestions { get; set; }
	}
}