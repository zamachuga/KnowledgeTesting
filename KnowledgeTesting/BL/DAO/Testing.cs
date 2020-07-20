using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Проведение тестирования.
	/// </summary>
	public class Testing
	{
		public int Id { get; set; }
		/// <summary>
		/// Кто проходил тест.
		/// </summary>
		public Interviewee Interviewees { get; set; }
		/// <summary>
		/// Какой проходил тест.
		/// </summary>
		public Test Test { get; set; }
		/// <summary>
		/// Какой был вопрос и какой был к нему ответ.
		/// </summary>
		public Question Questions { get; set; }
		public Answer Answer { get; set; }
	}
}