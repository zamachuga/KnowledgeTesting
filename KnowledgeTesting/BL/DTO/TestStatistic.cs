using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.BL.DTO
{
	/// <summary>
	/// Статистика прохождения теста.
	/// </summary>
	public class TestStatistic
	{
		/// <summary>
		/// Количество прохождений теста.
		/// </summary>
		public int CountComplete { get; set; }

		/// <summary>
		/// Данные по вопросам и ответам.
		/// 0 - номера вопросов.
		/// 1 - правильных ответов на вопросы.
		/// 2 - неправильных ответов на вопросы.
		/// </summary>
		public int[][] ArrayData { get; set; }
	}
}