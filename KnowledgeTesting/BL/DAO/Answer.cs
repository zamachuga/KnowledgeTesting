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
		public int Id { get; set; }
		public string Text { get; set; }
		public List<Question> Questions { get; set; }
		//public List<Question> CorrectQuestions { get; set; }
	}
}