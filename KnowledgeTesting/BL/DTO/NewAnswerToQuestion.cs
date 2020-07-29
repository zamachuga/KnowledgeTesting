using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Модель нового ответа на вопрос.
	/// (создание нового ответа).
	/// </summary>
	public class NewAnswerToQuestion
	{
		/// <summary>
		/// Код вопроса.
		/// </summary>
		public int QuestionId { get; set; }
		/// <summary>
		/// Текст вопроса.
		/// </summary>
		public string AnswerText { get; set; }
	}
}