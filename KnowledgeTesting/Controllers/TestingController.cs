using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeTesting.BL;
using DTO = KnowledgeTesting.BL.DTO;
using DAO = KnowledgeTesting.BL.DAO;

namespace KnowledgeTesting.Controllers
{
	/// <summary>
	/// Прохождение тестирования.
	/// </summary>
	public class TestingController : Controller
	{
		InterviweeManagement m_InterviweeManagement = new InterviweeManagement();
		TestManagement m_TestManagement = new TestManagement();
		QuestionManagement m_QuestionManagement = new QuestionManagement();
		AnswerManagement m_AnswerManagement = new AnswerManagement();
		Testing m_Testing = new Testing();

		/// <summary>
		/// Аутентификация тестируемого.
		/// </summary>
		[HttpPost]
		public string Auth(DTO.Interviwee DtoInterviwee)
		{
			DAO.Interviwee _DaoInterviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.LastName, DtoInterviwee.FirstName, DtoInterviwee.SecondName);

			if (_DaoInterviwee == null)
			{
				_DaoInterviwee = Utils.ConverObjectByJson<DAO.Interviwee>(DtoInterviwee);
				m_InterviweeManagement.CreateInterviwee(_DaoInterviwee);

				_DaoInterviwee = m_InterviweeManagement.GetInterviwee(DtoInterviwee.LastName, DtoInterviwee.FirstName, DtoInterviwee.SecondName);
			}

			DTO.Interviwee _DtoInterviwee = Utils.ConverObjectByJson<DTO.Interviwee>(_DaoInterviwee);
			string _Json = Utils.JsonSerialize(_DtoInterviwee);

			return _Json;
		}

		/// <summary>
		/// Начать прохождение теста.
		/// </summary>
		/// TODO: нужен рефакторинг.
		/// <returns></returns>
		[HttpPost]
		public string StartTest(DTO.InterviweeTest DtoInterviweeTest)
		{
			DAO.Interviwee _DaoInterviwee = m_InterviweeManagement.GetInterviwee(DtoInterviweeTest.InterviweeId);
			DAO.Test _DaoTest = m_TestManagement.GetTest(DtoInterviweeTest.TestId);
			DAO.InterviweeTests _DaoInterviweeTest = m_Testing.GetTesting(_DaoInterviwee, _DaoTest, true);
			DTO.InterviweeTest _DtoInterviweeTest = Utils.ConverObjectByJson<DTO.InterviweeTest>(_DaoInterviweeTest);

			string _Json = GetNextQuestion(_DtoInterviweeTest);
			return _Json;
		}

		/// <summary>
		/// Получить следующий вопрос.
		/// </summary>
		[HttpPost]
		public string GetNextQuestion(DTO.InterviweeTest DtoInterviweeTest)
		{
			DTO.InterviweeTest _DtoInterviweeTest = DtoInterviweeTest;

			// Прохождение теста.
			DAO.InterviweeTests _DaoInterviweeTest = GetInterviweeTestById(ref _DtoInterviweeTest);

			// Текущий вопрос.
			DAO.Question _CurrentQuestion = m_QuestionManagement.GetQuestion(DtoInterviweeTest.CurrentQuestion.Id);

			// Вопрос.
			_DtoInterviweeTest = GetNextQuestion(_DtoInterviweeTest, _DaoInterviweeTest, _CurrentQuestion);

			// Прогресс прохождения теста текстом.
			_DtoInterviweeTest.ProgressText = GetTextProgressTesting(_DaoInterviweeTest);

			string _Json = Utils.JsonSerialize(_DtoInterviweeTest);
			return _Json;
		}

		/// <summary>
		/// Ответить на вопрос.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public string AnswerTheQuestion(DTO.InterviweeTest DtoInterviweeTest)
		{
			DTO.InterviweeTest _DtoInterviweeTest = DtoInterviweeTest;

			// Прохождение теста.
			DAO.InterviweeTests _DaoInterviweeTest = GetInterviweeTestById(ref _DtoInterviweeTest);

			// Текущий вопрос.
			DAO.Question _CurrentQuestion = m_QuestionManagement.GetQuestion(_DtoInterviweeTest.CurrentQuestion.Id);

			// Ответ на вопрос.
			DAO.Answer _Answer = m_AnswerManagement.GetAnswer(_DtoInterviweeTest.CurrentQuestion.SelectedAnswerId);
			m_Testing.AnswerToQuestion(_DaoInterviweeTest, _CurrentQuestion, _Answer);

			// Прохождение теста - обновление после ответа.
			_DaoInterviweeTest = GetInterviweeTestById(ref _DtoInterviweeTest);

			// Вопрос.
			_DtoInterviweeTest = GetNextQuestion(_DtoInterviweeTest, _DaoInterviweeTest, _CurrentQuestion);

			// Прогресс прохождения теста текстом.
			_DtoInterviweeTest.ProgressText = GetTextProgressTesting(_DaoInterviweeTest);

			string _Json = Utils.JsonSerialize(_DtoInterviweeTest);
			return _Json;
		}

		/// <summary>
		/// Получить текст статуса прохождения теста.
		/// </summary>
		/// <returns></returns>
		private string GetTextProgressTesting(DAO.InterviweeTests DaoInterviweeTest)
		{
			int _Questions = m_Testing.GetCountQuestions(DaoInterviweeTest);
			int _QuestionsComplete = m_Testing.GetCountCompletedQuestion(DaoInterviweeTest);
			int _CorrectAnswers = m_Testing.GetCountCorrectAnswers(DaoInterviweeTest);

			return $"пройдено вопросов [{_QuestionsComplete}/{_Questions}] правильных ответов [{_CorrectAnswers}]";
		}

		/// <summary>
		/// Получить прохождение теста.
		/// </summary>
		/// <param name="DtoInterviweeTest"></param>
		/// <returns></returns>
		private DAO.InterviweeTests GetInterviweeTestById(ref DTO.InterviweeTest DtoInterviweeTest)
		{
			if (DtoInterviweeTest.Id <= 0) throw new ArgumentException("Не задан Id входящего параметра.") ;

			DAO.InterviweeTests _DaoInterviweeTest = m_Testing.GetTesting(DtoInterviweeTest.Id);
			DTO.InterviweeTest _DtoInterviweeTest = Utils.ConverObjectByJson<DTO.InterviweeTest>(_DaoInterviweeTest);

			DtoInterviweeTest = _DtoInterviweeTest;
			return _DaoInterviweeTest;
		}

		/// <summary>
		/// Получить следующий вопрос.
		/// </summary>
		/// <returns></returns>
		private DTO.InterviweeTest GetNextQuestion(
			DTO.InterviweeTest DtoInterviweeTest,
			DAO.InterviweeTests DaoInterviweeTest,
			DAO.Question CurrentQuestion)
		{
			DTO.InterviweeTest _DtoInterviweeTest = DtoInterviweeTest;

			// Вопрос.
			DAO.Question _DaoQuestion = m_Testing.GetNextQuestion(DaoInterviweeTest, CurrentQuestion);

			if (_DaoQuestion == null)
			{
				_DtoInterviweeTest.CurrentQuestion = new DTO.Question();
				return _DtoInterviweeTest;
			}

			if (_DaoQuestion != null)
			{
				_DtoInterviweeTest.CurrentQuestion = Utils.ConverObjectByJson<DTO.Question>(_DaoQuestion);

				// Ответы на вопрос.
				DAO.QuestionAnswers[] _DaoQuestionAnswers = _DaoQuestion.Answers.ToArray();
				List<DTO.QuestionAnswers> _ListAnswers = new List<DTO.QuestionAnswers>();
				foreach (var _DaoQuestionAnswer in _DaoQuestionAnswers)
				{
					_ListAnswers.Add(new DTO.QuestionAnswers()
					{
						AnswerId = _DaoQuestionAnswer.Answer.Id,
						AnswerText = _DaoQuestionAnswer.Answer.Text,
						IsCorrect = false,
						QuestionId = _DaoQuestionAnswer.QuestionId
					});
				}
				_DtoInterviweeTest.CurrentQuestion.Answers = _ListAnswers;
			}

			return _DtoInterviweeTest;
		}
	}
}