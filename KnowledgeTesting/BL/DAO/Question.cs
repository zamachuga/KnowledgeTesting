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
			Answers = new List<QuestionAnswers>();
			Tests = new List<TestQuestions>();
		}

		public int Id { get; set; }
		public string Text { get; set; }
		/// <summary>
		/// Вопросы.
		/// </summary>
		public virtual List<QuestionAnswers> Answers { get; set; }
		/// <summary>
		/// Тесты в которых содержится вопрос.
		/// </summary>
		public virtual List<TestQuestions> Tests { get; set; }
	}
}