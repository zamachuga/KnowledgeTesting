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
	public class TestManagementViewModel
	{
		public List<Test> Tests { get; set; }
		public Test CurrentSelectedTest { get; set; }

		public TestManagementViewModel()
		{
			Tests = new List<Test>();
		}
	}
}