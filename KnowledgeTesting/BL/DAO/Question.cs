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
			Tests = new List<Test>();
			Answers = new List<Answer>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		/// <summary>
		/// Тесты в которых участвует вопрос.
		/// </summary>
		public List<Test> Tests { get; set; }
		/// <summary>
		/// Ответы на вопрос.
		/// </summary>
		public List<Answer> Answers { get; set; }
	}
}