using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопрос.
	/// </summary>
	public class ClassQuestion
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public List<ClassAnswer> Answers { get; }
		public ClassAnswer CorrectAnswer { get; set; }

		public ClassQuestion()
		{
			Answers = new List<ClassAnswer>();
		}
	}
}