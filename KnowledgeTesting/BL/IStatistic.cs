using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTesting.BL
{

	/// <summary>
	/// Статистика.
	/// </summary>
	public interface IStatistic
	{
		/// <summary>
		/// Количество прохождений теста.
		/// </summary>
		/// <param name="Interviwee"></param>
		/// <param name=""></param>
		/// <returns></returns>
		int GetCountCompleteTest(int InterviweeId, int TestId);

		/// <summary>
		/// Получить многомерный массив статистики вопросов.
		/// 0 - номера вопросов.
		/// 1 - правильных ответов на вопросы.
		/// 2 - неправильных ответов на вопросы.
		/// </summary>
		int[][] GetArrayQuestionStatistic(int TestId);
	}
}
