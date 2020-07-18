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
		public List<ClassTest> Tests { get; set; }
		public ClassTest CurrentSelectedTest { get; set; }

		public TestManagementViewModel()
		{
			Tests = new List<ClassTest>();
		}
	}
}