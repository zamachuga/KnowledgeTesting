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
		/// TODO: тут большуший косяк
		/// промахнулся с полем и указал InterviweeId вместо InterviweeTests.
		public int Id { get; set; }
		public int InterviweeTestsId { get; set; }
		public InterviweeTests InterviweeTests { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public int AnswerId { get; set; }
		public Answer Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}