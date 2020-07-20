using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопрос.
	/// </summary>
	public class Question
	{
		public Question()
		{
			Answers = new List<Answer>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		public ICollection<Answer> Answers { get; set; }
	}
}