using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;
using KnowledgeTesting.BL;

namespace KnowledgeTesting.Controllers
{
	public class StatisticsController : Controller
	{
		InterviweeManagement m_InterviweeManagement = new InterviweeManagement();

		[HttpPost]
		public string GetTestsInterviwee(DTO.Interviwee DtoInterviwee)
		{
			DAO.Interviwee _Interviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.Id);
			//List<DAO.InterviweeTests> _ListInterviweeTests = _Interviwee.Tests;

			DAO.Test[] _DaoTests = m_InterviweeManagement.GetTests(_Interviwee);
			DTO.Test[] _DtoTests = Utils.ConverObjectByJson<DTO.Test[]>(_DaoTests);

			string _Json = Utils.JsonSerialize(_DtoTests);
			return _Json;
		}
	}
}