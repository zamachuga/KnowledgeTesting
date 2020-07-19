using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.Models
{
	public class CreateTestViewModel
	{
		public DTO.Test Test { get; set; }
		public string Notification { get; set; }
	}
}