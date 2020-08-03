using KnowledgeTesting.BL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление вопросами.
	/// </summary>
	public interface IQuestionManagement
	{
		/// <summary>
		/// Получить вопрос по коду.
		/// </summary>
		/// <param name="QuestionId">Код вопроса.</param>
		/// <returns></returns>
		Question GetQuestion(int QuestionId);

		/// <summary>
		/// Получить список всех квестов.
		/// </summary>
		/// <param name="FilterName">Фильтр по наименованию.</param>
		/// <returns></returns>
		DAO.Question[] GetAllQuestions(string FilterName);

		/// <summary>
		/// Установить правильный ответ на вопрос.
		/// </summary>
		void SetCorrectAnswer(DAO.Question Question, DAO.Answer Answer);

		/// <summary>
		/// Получить ответ на вопрос.
		/// (содержится в вопросе).
		/// </summary>
		/// <param name="QuestionId">Код вопроса.</param>
		/// <param name="AnswerId">Код ответа.</param>
		/// <returns></returns>
		QuestionAnswers GetAnswer(int QuestionId, int AnswerId);

		/// <summary>
		/// Удалить ответ из вопроса.
		/// </summary>
		/// <param name="QuestionAnswer"></param>
		void RemoveAnswer(DAO.QuestionAnswers QuestionAnswer);

		/// <summary>
		/// Добавить вариант ответа в вопрос.
		/// </summary>
		/// <param name="Question"></param>
		/// <param name="Answer"></param>
		void AddAnswer(DAO.Question Question, params DAO.Answer[] Answer);

		/// <summary>
		/// Создать вопрос.
		/// </summary>
		void CreateQuestion(params DAO.Question[] Questions);

		/// <summary>
		/// Сохранить изменение вопроса.
		/// </summary>
		/// <param name="Question">Вопрос.</param>
		void SaveQuestion(DAO.Question Question);
	}
}