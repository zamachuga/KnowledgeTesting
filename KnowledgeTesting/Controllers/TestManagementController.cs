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

			if (CheckTest(_Model.Test, out _Notification))
			{
				_Notification = $"Тест <{_Model.Test.Name}> сохранен.";
			}

			_Model.Notification = _Notification;

			return CreateTest(_Model);
		}

		private bool CheckTest(DTO.Test Test, out string Log)
		{
			bool _IsValid = true;
			string _Log = "";
			int _MaxLengthName = 254;
			int _MaxLengthDescription = 500;
			int _MaxQuestions = 10;

			if (string.IsNullOrEmpty(Test.Name))
			{
				_IsValid = false;
				_Log += "Название должно быть заполнено.";
			}

			if (Test.Name?.Length > _MaxLengthName)
			{
				_IsValid = false;
				_Log += $"Название не должно быть больше {_MaxLengthName} символов, сейчас <{Test.Name.Length}>.";
			}

			if (Test.Description?.Length > _MaxLengthName)
			{
				_IsValid = false;
				_Log += $"Название не должно быть больше {_MaxLengthDescription} символов, сейчас <{Test.Description.Length}>.";
			}

			if(Test.Questions?.Count() > _MaxQuestions)
			{
				_IsValid = false;
				_Log += $"Вопросов не должно быть больше {_MaxQuestions} символов, сейчас <{Test.Questions.Count()}>.";
			}

			Log = _Log;
			return _IsValid;
		}

		public string GetQuestions()
		{
			DTO.Question[] _Questions = _TestManagement.GetQuestions();
			return JsonConvert.SerializeObject(_Questions);
		}
	}
}