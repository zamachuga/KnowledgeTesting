using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопрос теста.
	/// </summary>
	public class TestQuestion
	{
		public int Id { get; set; }
		public Test Test { get; set; }
		public Question Question { get; set; }
	}
}