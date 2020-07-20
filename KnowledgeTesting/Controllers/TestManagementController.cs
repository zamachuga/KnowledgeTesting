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

		public ActionResult Index(TestsViewModel Model)
		{
			return View(Model);
		}

		public ActionResult CreateTest(CreateTestModel Model)
		{
			CreateTestModel _Model = Model;

			ViewBag.Questions = new SelectList(_TestManagement.GetQuestions(), "Id", "Text");

			return View(Model);
		}

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		/// <param name="Model"></param>
		/// <returns></returns>
		public ActionResult AddQuestion(CreateTestModel Model)
		{
			CreateTestModel _Model = Model;

			string _Notification = "";

			DTO.Question _Question = _TestManagement.GetQuestions().First(x => x.Id == _Model.SelectedQuestionId);
			_Model.Test.Questions.Add(_Question);

			_Model.Notification = _Notification;

			return CreateTest(_Model);
		}

		public ActionResult SaveNewTest(CreateTestModel Model)
		{
			CreateTestModel _Model = Model;
			string _Notification = "";

			if (_TestManagement.CheckTestData(_Model.Test, out _Notification))
			{
				_Notification = $"Тест <{_Model.Test.Name}> сохранен.";
			}

			_Model.Notification = _Notification;

			return CreateTest(_Model);
		}

		public string GetQuestions()
		{
			DTO.Question[] _Questions = _TestManagement.GetQuestions();
			return JsonConvert.SerializeObject(_Questions);
		}
	}
}