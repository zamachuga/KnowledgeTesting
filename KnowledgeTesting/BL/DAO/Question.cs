using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		/// <summary>
		/// Вопросы.
		/// </summary>
		public ICollection<Answer> Answers { get; set; }
		/// <summary>
		/// Правильный ответ на вопрос.
		/// </summary>
		public int? AnswerId { get; set; }
		/// <summary>
		/// Правильный ответ на вопрос.
		/// </summary>
		public Answer CorrectAnswer { get; set; }
	}
}