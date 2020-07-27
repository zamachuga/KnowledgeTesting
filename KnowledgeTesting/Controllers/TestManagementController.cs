using KnowledgeTesting.BL;
using System.Linq;
using System.Web.Mvc;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.Controllers
{
	public class TestManagementController : Controller
	{
		TestManagement m_TestManagement = new TestManagement();
		QuestionManagement m_QuestionManagement = new QuestionManagement();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public string GetAllTests()
		{
			DAO.Test[] _AllTests = m_TestManagement.GetAllTests();
			DTO.Test[] _DtoAllTests = Utils.ConverObjectByJson<DTO.Test[]>(_AllTests);

			string _JsonFormat = Utils.JsonSerialize(_DtoAllTests);

			return _JsonFormat;
		}

		/// <summary>
		/// Получить информацию по тесту.
		/// </summary>
		/// <param name="Id">Код теста.</param>
		/// <returns></returns>
		[HttpPost]
		public string GetTest(int Id)
		{
			DAO.Test _Test = m_TestManagement.GetTest(Id);
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
			DAO.Test _DaoTest = m_TestManagement.GetTest(DtoTest.Id);
			_DaoTest.Name = DtoTest.Name;
			_DaoTest.Description = DtoTest.Description;

			m_TestManagement.SaveTest(_DaoTest);

			return string.Empty;
		}

		[HttpPost]
		public string CreateTest(DTO.Test DtoTest)
		{
			DAO.Test _DaoTest = Utils.ConverObjectByJson<DAO.Test>(DtoTest);

			m_TestManagement.CreateTest(_DaoTest);

			return string.Empty;
		}

		/// <summary>
		/// Получить список вопросов для теста.
		/// </summary>
		/// <param name="Id">Код теста.</param>
		/// <returns></returns>
		[HttpPost]
		public string GetListQuestionForTest(int Id)
		{
			DAO.Test _DaoTest = m_TestManagement.GetTest(Id);
			DAO.Question[] _DaoQuestions = _DaoTest.Questions.Select(x => x.Question).ToArray();

			DTO.Question[] _DtoQuestions = Utils.ConverObjectByJson<DTO.Question[]>(_DaoQuestions);
			string _DtoQuestionsJson = Utils.JsonSerialize(_DtoQuestions);

			return _DtoQuestionsJson;
		}

		/// <summary>
		/// Удалить вопрос из теста.
		/// </summary>
		/// <param name="DtoTestQuestion"></param>
		/// <returns></returns>
		[HttpPost]
		public string RemoveQuesion(DTO.TestQuestions DtoTestQuestion)
		{
			m_TestManagement.RemoveQuestion(DtoTestQuestion.TestId, DtoTestQuestion.QuestionId);
			return string.Empty;
		}

		/// <summary>
		/// Получить список всех вопросов.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string GetAllQuestions(string FilterName)
		{
			DAO.Question[] _DaoQuestions = m_QuestionManagement.GetAllQuestions(FilterName);

			DTO.Question[] _DtoQuestions = Utils.ConverObjectByJson<DTO.Question[]>(_DaoQuestions);
			string _Json = Utils.JsonSerialize(_DtoQuestions);

			return _Json;
		}

		[HttpPost]
		public string AddQuestionToTest(DTO.TestQuestions DtoTestQuestion)
		{
			DAO.Test _Test = m_TestManagement.GetTest(DtoTestQuestion.TestId);
			DAO.Question _Question = m_QuestionManagement.GetQuestion(DtoTestQuestion.QuestionId);

			if (_Test != null && _Question != null)
				m_TestManagement.AddQuestion(_Test, _Question);

			return string.Empty;
		}
	}
}