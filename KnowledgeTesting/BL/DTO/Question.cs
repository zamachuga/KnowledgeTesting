using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	public class Question
	{
		public Question()
		{
			Answers = new List<QuestionAnswers>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		public List<QuestionAnswers> Answers { get; set; }
	}
}