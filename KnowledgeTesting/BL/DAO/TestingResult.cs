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
		/// <summary>
		/// Прохождение теста.
		/// </summary>
		public int InterviweeTestsId { get; set; }
		/// <summary>
		/// Прохождение теста.
		/// </summary>
		public InterviweeTests InterviweeTests { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public int AnswerId { get; set; }
		public Answer Answer { get; set; }
		/// <summary>
		/// True - на вопрос ответили правильно.
		/// </summary>
		public bool IsCorrect { get; set; }
	}
}