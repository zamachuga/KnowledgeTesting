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

		public ActionResult Index()
		{
			TestManagementViewModel _Model = ViewBag.TestManagementViewModel;

			if(_Model== null) _Model = new TestManagementViewModel();

			ViewBag.TestManagementViewModel = new TestManagementViewModel();
			return View();
		}

		public ActionResult CreateTest()
		{
			CreateTestViewModel _Model = ViewBag.CreateTestViewModel;

			if (_Model == null) _Model = new CreateTestViewModel();

			if (_Model.Test == null)
			{
				DTO.Test _DtoTest = new DTO.Test();
				_Model.Test = _DtoTest;
			}

			_Model.Questions = new SelectList(_TestManagement.GetQuestions(), "Id", "Text");

			ViewBag.CreateTestViewModel = _Model;
			return View(_Model);
		}

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		/// <param name="Model"></param>
		/// <returns></returns>
		public ActionResult AddAnswer()
		{
			CreateTestViewModel _Model = ViewBag.CreateTestViewModel;
			bool _IsValid = true;

			if (_Model.Test.Questions.Count() >= 10)
			{
				_IsValid = false;
				_Model.Notification = "Вопросов не должно быть больше 10.";
			}

			if (_IsValid)
			{
				DTO.Question _Question = _TestManagement.GetQuestions().First(x => x.Id == _Model.SelectedQuestionId);
				_Model.Test.Questions.Add(_Question);
			}

			ViewBag.CreateTestViewModel = _Model;
			return View("CreateTest");
		}

		public ActionResult SaveNewTest()
		{
			CreateTestViewModel _Model = ViewBag.CreateTestViewModel;
			string _Notification = "";

			if (true)
			{
				_Notification = $"Тест <{_Model.Test.Name}> сохранен.";
			}

			_Model.Notification = _Notification;

			ViewBag.CreateTestViewModel = _Model;
			return View("CreateTest");
		}
	}
}