using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.Models
{
	public class CreateTestViewModel
	{
		public DTO.Test Test { get; set; }
		public SelectList Questions { get; set; }
		public int SelectedQuestionId { get; set; }
		public string Notification { get; set; }
	}
}