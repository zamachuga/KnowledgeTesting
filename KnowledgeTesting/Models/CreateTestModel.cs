using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.Models
{
	public class CreateTestModel
	{
		public CreateTestModel()
		{
			Test = new DTO.Test();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		/// <summary>
		/// Выбранный вопрос для добавления.
		/// </summary>
		public int SelectedQuestionId { get; set; }
		/// <summary>
		/// Уведомление.
		/// </summary>
		public string Notification { get; set; }
	}
}