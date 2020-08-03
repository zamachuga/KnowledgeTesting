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
		public StatisticsController(
			IInterviweeManagement InterviweeManagement,
			IStatistic Statistic
			)
		{
			m_InterviweeManagement = InterviweeManagement;
			m_Statistic = Statistic;
		}

		IInterviweeManagement m_InterviweeManagement;
		IStatistic m_Statistic;

		[HttpPost]
		public string GetTestsInterviwee(DTO.Interviwee DtoInterviwee)
		{
			DAO.Interviwee _Interviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.Id);

			DAO.Test[] _DaoTests = m_InterviweeManagement.GetCompleteTests(_Interviwee);
			DTO.Test[] _DtoTests = Utils.ConverObjectByJson<DTO.Test[]>(_DaoTests);

			string _Json = Utils.JsonSerialize(_DtoTests);
			return _Json;
		}

		[HttpPost]
		public string GetStatisticTest(DTO.InterviweeTest InterviweeTest)
		{
			// Статистика прохождения теста.
			DTO.TestStatistic _TestStatistic = new DTO.TestStatistic();

			// Количество прохождений теста.
			_TestStatistic.CountComplete = m_Statistic.GetCountCompleteTest(InterviweeTest.InterviweeId, InterviweeTest.TestId);

			// Статистика прохождений по вопросам.
			_TestStatistic.ArrayData = m_Statistic.GetArrayQuestionStatistic(InterviweeTest.TestId);

			string _Json = Utils.JsonSerialize(_TestStatistic);
			return _Json;
		}
	}
}