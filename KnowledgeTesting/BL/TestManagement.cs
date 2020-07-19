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
	}
}