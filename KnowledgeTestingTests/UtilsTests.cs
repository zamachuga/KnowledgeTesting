using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = KnowledgeTesting.BL;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTestingTests
{
	[TestFixture]
	public class UtilsTests
	{
		[Test]
		public void ConverObjectByJsonTest()
		{
			DTO.Question _Q = new DTO.Question() { Id = 11, Text = "sadadas" };
			DTO.Test _DtoTest = new DTO.Test() { Id = 1, Name = "sn", Description = "sdads"};
			_DtoTest.Questions.Add(_Q);



			DAO.Test _DaoTest = BL.Utils.ConverObjectByJson<DAO.Test>(_DtoTest);

			Assert.True(_DaoTest.Name == _DtoTest.Name);
			Assert.True(_DaoTest.Description == _DtoTest.Description);
			Assert.True(_DaoTest.Id == _DtoTest.Id);
			Assert.True(_DaoTest.Questions.Count() == _DtoTest.Questions.Count());
		}
	}
}