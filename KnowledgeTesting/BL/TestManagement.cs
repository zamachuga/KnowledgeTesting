using System;
using DAO = KnowledgeTesting.BL.DAO;
using DTO = KnowledgeTesting.BL.DTO;
using System.Linq;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестами.
	/// </summary>
	public class TestManagement
	{
		public TestManagement()
		{
			_DbContext = new DB.PgSql.ClassDbPgSqlContext();
		}

		DB.PgSql.ClassDbPgSqlContext _DbContext;

		/// <summary>
		/// Получить список вопросов.
		/// </summary>
		/// <returns>DTO представление вопросов.</returns>
		internal DTO.Question[] GetQuestions()
		{
			DAO.Question[] _DaoQuestions = _DbContext.Questions.Select(x => x).ToArray();
			DTO.Question[] _DtoQuestions = Utils.ConverArrayObjectsByJson<DTO.Question>(_DaoQuestions);

			return _DtoQuestions;
		}

		/// <summary>
		/// Создать тест.
		/// </summary>
		/// <param name="DtoTest">Набор данных теста с визуальной части.</param>
		public void CreateTest(DTO.Test DtoTest)
		{
			bool IsValid = CheckTestData(DtoTest);

			if (IsValid)
			{
				DAO.Test _Test = Utils.ConverObjectByJson<DAO.Test>(DtoTest);
				_DbContext.Tests.Add(_Test);
				_DbContext.SaveChanges();
			}
		}

		/// <summary>
		/// Проверить данные теста.
		/// </summary>
		/// <param name="Test"></param>
		/// <param name="Log"></param>
		/// <returns></returns>
		public bool CheckTestData(DAO.Test Test, out string Log)
		{
			bool _IsValid = true;
			string _Log = "";

			// Параметры проверки теста, лучше бы класс, но эта спешка...
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

			if (Test.Questions?.Count() > _MaxQuestions)
			{
				_IsValid = false;
				_Log += $"Вопросов не должно быть больше {_MaxQuestions} символов, сейчас <{Test.Questions.Count()}>.";
			}
			
			if (_DbContext.Tests.Select(x => x.Name.ToLower().Replace(" ", "") == Test.Name.ToLower().Replace(" ", "")).Count() == 0)
			{
				_IsValid = false;
				_Log += $"Тестс таким названием существует.";
			}

			Log = _Log;
			return _IsValid;
		}
		/// <summary>
		/// Проверить данные теста.
		/// </summary>
		/// <param name="Test"></param>
		/// <param name="Log"></param>
		/// <returns></returns>
		public bool CheckTestData(DTO.Test Test) {
			string _Log = "";
			DAO.Test _Test = Utils.ConverObjectByJson<DAO.Test>(Test);

			return CheckTestData(_Test, out _Log);
		}
		/// <summary>
		/// Проверить данные теста.
		/// </summary>
		/// <param name="Test"></param>
		/// <param name="Log"></param>
		/// <returns></returns>
		public bool CheckTestData(DTO.Test Test, out string Log)
		{
			DAO.Test _Test = Utils.ConverObjectByJson<DAO.Test>(Test);

			return CheckTestData(_Test, out Log);
		}
		/// <summary>
		/// Проверить данные теста.
		/// </summary>
		/// <param name="Test"></param>
		/// <param name="Log"></param>
		/// <returns></returns>
		public bool CheckTestData(DAO.Test Test)
		{
			string _Log = "";
			return CheckTestData(Test, out _Log);
		}

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		/// <param name=""></param>
		public void AddQuestion(int QuestionId, int QuestId)
		{
			DAO.Question _Question = _DbContext.Questions.First(x => x.Id == QuestionId);
			DAO.Test _Test = _DbContext.Tests.First(x => x.Id == QuestId);

			_Test.Questions.Add(_Question);

			CheckTestData(_Test);
		}
	}
}