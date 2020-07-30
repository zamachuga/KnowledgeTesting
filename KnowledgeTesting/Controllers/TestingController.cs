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
	public class TestingController : Controller
	{
		InterviweeManagement m_InterviweeManagement = new InterviweeManagement();

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
	}
}