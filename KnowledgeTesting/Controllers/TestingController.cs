using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeTesting.Controllers
{
	public class TestingController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Страница проведения тестирования.";

			return View();
		}
	}
}