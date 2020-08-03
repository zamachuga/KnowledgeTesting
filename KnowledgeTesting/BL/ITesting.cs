using KnowledgeTesting.BL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление проведением тестирования.
	/// </summary>
	public interface ITesting
	{
		/// <summary>
		/// Начать/получить процесс тестирования.
		/// </summary>
		DAO.InterviweeTests StartTesting(DAO.Interviwee Interviwee, DAO.Test Test);

		/// <summary>
		/// Ответить на вопрос.
		/// </summary>
		/// <param name="InterviweeTestId">Прохождение теста.</param>
		/// <param name="QuestionId">Вопрос.</param>
		/// <param name="AnswerId">Ответ.</param>
		void AnswerToQuestion(
			DAO.InterviweeTests InterviweeTest, 
			DAO.Question Question, 
			DAO.Answer Answer
		);

		/// <summary>
		/// Опделить статус завершения теста.
		/// </summary>
		/// <returns></returns>
		void DetermineStatusComplete(DAO.InterviweeTests InterviweeTest);

		/// <summary>
		/// Получить количество вопросов.
		/// </summary>
		int GetCountQuestions(DAO.InterviweeTests InterviweeTest);

		/// <summary>
		/// Получить количество ответов на вопрсы.
		/// </summary>
		int GetCountCompletedQuestion(DAO.InterviweeTests InterviweeTest);

		/// <summary>
		/// Получить количество правильных ответов.
		/// </summary>
		int GetCountCorrectAnswers(DAO.InterviweeTests InterviweeTest);

		/// <summary>
		/// Получить процесс тестирования.
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		InterviweeTests GetTesting(int Id);

		/// <summary>
		/// Получить следующий вопрос для прохождения теста.
		/// </summary>
		/// <param name="InterviweeTests">Прохождение теста.</param>
		/// <returns></returns>
		DAO.Question GetNextQuestion(
			DAO.InterviweeTests InterviweeTest,
			DAO.Question ExcludeQuestion = null
		);
	}
}
