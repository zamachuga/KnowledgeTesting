using KnowledgeTesting.BL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.Models
{
	/// <summary>
	/// Просмотр существующих тестов.
	/// </summary>
	public class TestsViewModel
	{
		public List<Test> Tests { get; set; }

		public TestsViewModel()
		{
			Tests = new List<Test>();
		}
	}
}