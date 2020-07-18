using KnowledgeTesting.BL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестами.
	/// </summary>
	public class ClassTestManagement
	{
		public void CreateTest(ClassTest Test)
		{
			if (Test.Id != 0) return;
		}

		public ClassTest ReadTest(int Id)
		{
			return null;
		}

		public void UpdateTest(ClassTest Test)
		{
			if (Test.Id == 0) return;
		}

		public void DeleteTest(int Id)
		{
			if (Id == 0) return;
		}
	}
}