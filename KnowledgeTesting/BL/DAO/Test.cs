using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Тест.
	/// </summary>
	public class Test
	{
		public Test()
		{
			Questions = new List<Question>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Question> Questions { get; private set; }
	}
}