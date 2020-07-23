﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Тест.
	/// </summary>
	public class Test
	{
		public Test()
		{
			Questions = new List<TestQuestions>();
			Interviwees = new List<InterviweeTests>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		/// <summary>
		/// Вопросы в тесте.
		/// </summary>
		public virtual List<TestQuestions> Questions { get; set; }
		/// <summary>
		/// Прохождения теста.
		/// </summary>
		public virtual List<InterviweeTests> Interviwees { get; set; }
	}
}