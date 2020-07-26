using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL = KnowledgeTesting.BL;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;
using Newtonsoft.Json;
using DB = KnowledgeTesting.BL.DB.PgSql;
using KnowledgeTesting.BL;

namespace KnowledgeTesting.Controllers
{
	public class TestManagementController : Controller
	{
		BL.TestManagement _TestManagement = new BL.TestManagement();
		BL.QuestionManagement _QuestionManagement = new QuestionManagement();
		//DB.DbPgSqlContext _DbContext = DB.DbPgSqlContext.Instance();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public string GetAllTests()
		{
			DAO.Test[] _AllTests = _TestManagement.GetAllTests();
			DTO.Test[] _DtoAllTests = Utils.ConverObjectByJson<DTO.Test[]>(_AllTests);

			string _JsonFormat = Utils.JsonSerialize(_DtoAllTests);

			return _JsonFormat;
		}

		[HttpPost]
		public string GetTest(int Id)
		{
			DAO.Test _Test = _TestManagement.GetTest(Id);
			DTO.Test _DtoTest = Utils.ConverObjectByJson<DTO.Test>(_Test);

			string _JsonFormat = Utils.JsonSerialize(_DtoTest);

			return _JsonFormat;
		}

		/// <summary>
		/// Сохранить изменения по тесту.
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		[HttpPost]
		public string SaveChangeTest(DTO.Test DtoTest)
		{
			_TestManagement.SaveTest(DtoTest);
			return string.Empty;
		}

		[HttpPost]
		public string CreateTest(DTO.Test DtoTest)
		{
			_TestManagement.CreateTest(DtoTest);
			return string.Empty;
		}

		[HttpPost]
		public string GetListQuestionForTest(int Id)
		{
			_QuestionManagement.get
		}

		//public ActionResult CreateTest(CreateTestModel Model)
		//{
		//	CreateTestModel _Model = Model;

		//	ViewBag.Questions = new SelectList(GetQuestionsDtoModels(), "Id", "Text");

		//	return View(Model);
		//}

		///// <summary>
		///// Добавить вопрос в тест.
		///// </summary>
		///// <param name="Model"></param>
		///// <returns></returns>
		//public ActionResult AddQuestion(CreateTestModel Model)
		//{
		//	CreateTestModel _Model = Model;

		//	string _Notification = "";

		//	DTO.Question _Question = GetQuestionsDtoModels().First(x => x.Id == _Model.SelectedQuestionId);
		//	_Model.Test.Questions.Add(_Question);

		//	_Model.Notification = _Notification;

		//	return CreateTest(_Model);
		//}

		//public ActionResult SaveNewTest(CreateTestModel Model)
		//{
		//	CreateTestModel _Model = Model;
		//	string _Notification = "";

		//	if (_TestManagement.CheckTestData(_Model.Test, out _Notification))
		//	{
		//		_Notification = $"Тест <{_Model.Test.Name}> сохранен.";
		//	}

		//	_Model.Notification = _Notification;

		//	return CreateTest(_Model);
		//}

		//public string GetQuestions()
		//{
		//	DTO.Question[] _Questions = GetQuestionsDtoModels();
		//	return JsonConvert.SerializeObject(_Questions);
		//}

		//private DTO.Question[] GetQuestionsDtoModels()
		//{
		//	DTO.Question[] _Questions = _DbContext.Questions.Select(
		//		x => new DTO.Question()
		//		{
		//			Id = x.Id,
		//			Text = x.Text
		//		}
		//	).ToArray();

		//	return _Questions;
		//}
	}
}