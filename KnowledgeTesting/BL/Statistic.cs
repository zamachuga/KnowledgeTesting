using KnowledgeTesting.BL.DB.PgSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL
{
	public class Statistic
	{
		DbPgSqlContext _DbContext = DbPgSqlContext.Instance();

		/// <summary>
		/// Количество прохождений теста.
		/// </summary>
		/// <param name="Interviwee"></param>
		/// <param name=""></param>
		/// <returns></returns>
		public int GetCountCompleteTest(int InterviweeId, int TestId)
		{
			int _Count = _DbContext.InterviweeTests.Where(x => x.InterviweeId == InterviweeId & x.TestId == TestId).Count();
			return _Count;
		}

		/// <summary>
		/// Получить многомерный массив статистики вопросов.
		/// 0 - номера вопросов.
		/// 1 - правильных ответов на вопросы.
		/// 2 - неправильных ответов на вопросы.
		/// </summary>
		public int[][] GetArrayQuestionStatistic(int TestId)
		{
			int[][] _ArrayStatistic = new int[3][];

			// Вопросы.
			int[] Questions = _DbContext.TestQuestions
				.Where(x => x.TestId == TestId)
				.Select(x => x.QuestionId)
				.ToArray();
			_ArrayStatistic[0] = Questions;

			// Стастистика по вопросам.
			_ArrayStatistic[1] = new int[Questions.Count()];
			_ArrayStatistic[2] = new int[Questions.Count()];
			for (int i = 0; i < Questions.Count(); i++)
			{
				int _QuestionId = Questions[i];
				int _Count = 0;

				// Список Id прохождений теста.
				int[] _ArrayInterviweeTestsId = _DbContext.InterviweeTests
					.Where(x => x.TestId == TestId)
					.Select(x => x.Id)
					.ToArray();

				// Правильные ответы.
				_Count = _DbContext.TestingResults
					.Where(x => _ArrayInterviweeTestsId.Contains(x.InterviweeTestsId) & x.IsCorrect & x.QuestionId == _QuestionId)
					.Count()
					;
				_ArrayStatistic[1][i] = _Count;

				// Неправильные ответы.
				_Count = _DbContext.TestingResults
					.Where(x => _ArrayInterviweeTestsId.Contains(x.InterviweeTestsId) & !x.IsCorrect & x.QuestionId == _QuestionId)
					.Count()
					;
				_ArrayStatistic[2][i] = _Count;
			}

			return _ArrayStatistic;
		}
	}
}