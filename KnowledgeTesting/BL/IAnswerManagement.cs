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
	public interface IAnswerManagement
	{
		/// <summary>
		/// Создать ответ.
		/// </summary>
		/// <param name="Answer">Ответ.</param>
		void CreateAnswer(DAO.Answer Answer);

		/// <summary>
		/// Получить ответ.
		/// </summary>
		/// <param name="Id">Код.</param>
		/// <returns></returns>
		DAO.Answer GetAnswer(int Id);

		/// <summary>
		/// Получить ответ.
		/// </summary>
		/// <param name="Id">Код.</param>
		/// <returns></returns>
		DAO.Answer GetAnswer(string Text);

		/// <summary>
		/// Получить все ответы.
		/// </summary>
		/// <returns></returns>
		DAO.Answer[] GetAllAnswers();
	}
}
