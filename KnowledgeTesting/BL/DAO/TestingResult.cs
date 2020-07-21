using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Результаты проведения тестирования.
	/// </summary>
	public class TestingResult
	{
		public int Id { get; set; }
		public int InterviweeId { get; set; }
		public Interviwee Interviwee { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public int AnswerId { get; set; }
		public Answer Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}