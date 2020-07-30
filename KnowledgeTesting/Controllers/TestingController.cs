using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeTesting.BL;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.Controllers
{
	/// <summary>
	/// Прохождение тестирования.
	/// </summary>
	public class TestingController : Controller
	{
		InterviweeManagement m_InterviweeManagement = new InterviweeManagement();
		TestManagement m_TestManagement = new TestManagement();
		Testing m_Testing = new Testing();

		/// <summary>
		/// Аутентификация тестируемого.
		/// </summary>
		[HttpPost]
		public string Auth(DTO.Interviwee DtoInterviwee)
		{
			DAO.Interviwee _DaoInterviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.LastName, DtoInterviwee.FirstName, DtoInterviwee.SecondName);

			if (_DaoInterviwee == null)
			{
				_DaoInterviwee = Utils.ConverObjectByJson<DAO.Interviwee>(DtoInterviwee);
				m_InterviweeManagement.CreateInterviwee(_DaoInterviwee);

				_DaoInterviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.LastName, DtoInterviwee.FirstName, DtoInterviwee.SecondName);
			}

			DTO.Interviwee _DtoInterviwee = Utils.ConverObjectByJson<DTO.Interviwee>(_DaoInterviwee);
			string _Json = Utils.JsonSerialize(_DtoInterviwee);

			return _Json;
		}

		/// <summary>
		/// Начать прохождение теста.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public DTO.InterviweeTest StartTest(DTO.InterviweeTest DtoInterviweeTest)
		{
			DTO.InterviweeTest _DtoInterviweeTest = DtoInterviweeTest;
			DAO.Interviwee _DaoInterviwee = m_InterviweeManagement.GetInterviwee(_DtoInterviweeTest.InterviweeId);
			DAO.Test _DaoTest = m_TestManagement.GetTest(_DtoInterviweeTest.TestId);

			DAO.InterviweeTests _DaoInterviweeTest = m_Testing.StartTest(_DaoInterviwee, _DaoTest);
			DAO.Question _DaoQuestion = m_Testing.GetNextQuestion(_DaoInterviweeTest);

			_DtoInterviweeTest = Utils.ConverObjectByJson<DTO.InterviweeTest>(_DaoInterviweeTest);
			_DtoInterviweeTest.CurrentQuestion = Utils.ConverObjectByJson<DTO.Question>(_DaoQuestion);

			return _DtoInterviweeTest;
		}
	}
}