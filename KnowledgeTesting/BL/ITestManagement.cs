using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестами.
	/// </summary>
	public interface ITestManagement
	{
		/// <summary>
		/// Получить тест по коду.
		/// </summary>
		DAO.Test GetTest(int id);

		/// <summary>
		/// Сохранить изменения.
		/// </summary>
		/// <param name="Test">Объект для фиксирования изменений.</param>
		void SaveTest(DAO.Test Test);

		/// <summary>
		/// Создать тест.
		/// </summary>
		void CreateTest(DAO.Test Test);

		/// <summary>
		/// Получить все тесты.
		/// </summary>
		/// <returns></returns>
		DAO.Test[] GetAllTests();

		/// <summary>
		/// Удалить вопрос из теста.
		/// </summary>
		void RemoveQuestion(int TestId, int QuestionId);

		/// <summary>
		/// Добавить вопрос в тест.
		/// </summary>
		/// <param name="Test"></param>
		/// <param name="Question"></param>
		void AddQuestion(DAO.Test Test, DAO.Question Question);
	}
}
