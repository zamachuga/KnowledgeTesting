using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Тест.
	/// </summary>
	public class ClassTest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<ClassQuestion> Questions { get; }

		public ClassTest()
		{
			Questions = new List<ClassQuestion>();
		}
	}
}