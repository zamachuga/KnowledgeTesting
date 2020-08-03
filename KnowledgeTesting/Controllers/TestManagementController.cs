using KnowledgeTesting.BL;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.Controllers
{
	public class TestManagementController : Controller
	{
		public TestManagementController(
			IAnswerManagement AnswerManagement,
			IQuestionManagement QuestionManagement
			)
		{
			m_AnswerManagement = AnswerManagement;
			m_QuestionManagement = QuestionManagement;
		}

		TestManagement m_TestManagement = new TestManagement();
		IQuestionManagement m_QuestionManagement;
		IAnswerManagement m_AnswerManagement;
		//BL.DB.PgSql.DbPgSqlContext _DbContext = BL.DB.PgSql.DbPgSqlContext.Instance();

		/// <summary>
		/// Стартовая страница приложения.
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Получить список всех тестов.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Создать тест.
		/// </summary>
		/// <param name="DtoTest"></param>
		/// <returns></returns>
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
			// Получить список вопросов.
			var _DaoQuestions = m_QuestionManagement.GetAllQuestions(string.Empty);

			// Получить список ответов на вопросы.
			List<DTO.Question> _DtoQuestions = new List<DTO.Question>();
			foreach (var _DaoQuestion in _DaoQuestions)
			{
				// Вопрос.
				var _DtoQuestion = new DTO.Question() { Id = _DaoQuestion.Id, Text = _DaoQuestion.Text };
				// Ответы.
				foreach (var _DaoAnswers in _DaoQuestion.Answers)
				{
					DTO.QuestionAnswers _DtoAnswer = new DTO.QuestionAnswers()
					{
						QuestionId = _DaoAnswers.QuestionId,
						AnswerId = _DaoAnswers.Answer.Id,
						AnswerText = _DaoAnswers.Answer.Text,
						IsCorrect = _DaoAnswers.IsCorrect
					};

					_DtoQuestion.Answers.Add(_DtoAnswer);
				}

				_DtoQuestions.Add(_DtoQuestion);
			}

			string _Json = Utils.JsonSerialize(_DtoQuestions);
			return _Json;
		}

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		/// <param name="DtoTestQuestion"></param>
		/// <returns></returns>
		[HttpPost]
		public string AddQuestionToTest(DTO.TestQuestions DtoTestQuestion)
		{
			DAO.Test _Test = m_TestManagement.GetTest(DtoTestQuestion.TestId);
			DAO.Question _Question = m_QuestionManagement.GetQuestion(DtoTestQuestion.QuestionId);

			if (_Test != null && _Question != null)
				m_TestManagement.AddQuestion(_Test, _Question);

			return string.Empty;
		}

		/// <summary>
		/// Установить правильный ответ на вопрос.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string SetCorrectAnswer(DTO.QuestionAnswers CorrectAnswer)
		{
			DAO.Question _Question = m_QuestionManagement.GetQuestion(CorrectAnswer.QuestionId);
			DAO.Answer _Answer = m_AnswerManagement.GetAnswer(CorrectAnswer.AnswerId);

			m_QuestionManagement.SetCorrectAnswer(_Question, _Answer);
			return string.Empty;
		}

		/// <summary>
		/// Удалить ответ из вопроса.
		/// </summary>
		/// <param name="QuestionAnswer"></param>
		/// <returns></returns>
		[HttpPost]
		public string RemoveAnswerFromQuestion(DTO.QuestionAnswers QuestionAnswer)
		{
			DAO.QuestionAnswers _QuestionAnswer = m_QuestionManagement.GetAnswer(QuestionAnswer.QuestionId, QuestionAnswer.AnswerId);

			m_QuestionManagement.RemoveAnswer(_QuestionAnswer);
			return string.Empty;
		}

		/// <summary>
		/// Получить все ответы.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string GetAllAnswers()
		{
			DAO.Answer[] _DaoAnswers = m_AnswerManagement.GetAllAnswers();
			DTO.Answer[] _DtoAnswers = Utils.ConverObjectByJson<DTO.Answer[]>(_DaoAnswers);

			string _Json = Utils.JsonSerialize(_DtoAnswers);
			return _Json;
		}

		/// <summary>
		/// Добавить ответ в вопрос.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string AddAnswerToQuestion(DTO.QuestionAnswers QuestionAnswer)
		{
			DAO.Question _Question = m_QuestionManagement.GetQuestion(QuestionAnswer.QuestionId);
			DAO.Answer _Answer = m_AnswerManagement.GetAnswer(QuestionAnswer.AnswerId);

			m_QuestionManagement.AddAnswer(_Question, _Answer);
			return string.Empty;
		}

		/// <summary>
		/// Создать новый ответ для вопроса.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string CreateAnswerToQuestion(DTO.NewAnswerToQuestion NewAnswerToQuestion)
		{
			DAO.Answer _Answer = new DAO.Answer() { Text = NewAnswerToQuestion.AnswerText };
			DAO.Question _Question = m_QuestionManagement.GetQuestion(NewAnswerToQuestion.QuestionId);

			m_AnswerManagement.CreateAnswer(_Answer);

			_Answer = m_AnswerManagement.GetAnswer(NewAnswerToQuestion.AnswerText);
			if (_Answer != null)
				m_QuestionManagement.AddAnswer(_Question, _Answer);

			return string.Empty;
		}

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string CreateQuestion(DTO.Question DtoQuestion)
		{
			DAO.Question _DaoQuestion = new DAO.Question() { Text = DtoQuestion.Text };

			m_QuestionManagement.CreateQuestion(_DaoQuestion);
			return string.Empty;
		}

		/// <summary>
		/// Редактировать вопрос.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string EditQuestion(DTO.Question DtoQuestion)
		{
			DAO.Question _DaoQuestion = m_QuestionManagement.GetQuestion(DtoQuestion.Id);
			_DaoQuestion.Text = DtoQuestion.Text;

			m_QuestionManagement.SaveQuestion(_DaoQuestion);
			return string.Empty;
		}
	}
}