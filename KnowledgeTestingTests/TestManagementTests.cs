using KnowledgeTesting.BL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class TestManagementTests
	{
		TestManagement _TestManagement = new TestManagement();

		[Test]
		public void Test()
		{
			DTO.Test _Test = new DTO.Test();
			_Test.Name = "T1";
			_Test.Description = "Test 1 Nunit.";

			Assert.DoesNotThrow(() => _TestManagement.CreateTest(_Test));
		}


	}
}