using KnowledgeTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = KnowledgeTesting.BL;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;
using Newtonsoft.Json;

namespace KnowledgeTesting.Controllers
{
	public class TestManagementController : Controller
	{
		BL.TestManagement _TestManagement = new BL.TestManagement();

		public ActionResult Index(TestManagementViewModel Model)
		{
			TestManagementViewModel _Model = Model;

			return View(_Model);
		}

		public ActionResult CreateTest(CreateTestViewModel Model)
		{
			CreateTestViewModel _Model = Model;

			if (_Model == null) _Model = new CreateTestViewModel();

			if (_Model.Test == null) {
				DTO.Test _DtoTest = new DTO.Test();
				_Model.Test = _DtoTest;
			}

			return View(_Model);
		}

		public ActionResult SaveNewTest(CreateTestViewModel Model)
		{
			CreateTestViewModel _Model = Model;
			_Model.Notification = $"Тест <{_Model.Test.Name}> сохранен.";

			return View("CreateTest", _Model);
		}
	}
}