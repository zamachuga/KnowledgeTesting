using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Проведение тестирования.
	/// </summary>
	public class ClassTesting
	{
		public int Id { get; set; }
		public List<ClassInterviewee> Interviewees { get; set; }
		public List<ClassQuestion> Questions { get; set; }
	}
}