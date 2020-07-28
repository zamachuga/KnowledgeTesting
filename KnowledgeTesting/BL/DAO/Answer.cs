using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Ответ.
	/// </summary>
	public class Answer
	{
		public Answer()
		{
			Questions = new List<QuestionAnswers>();
		}

		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Text { get; set; }
		/// <summary>
		/// Вопросы в которых участвует ответ.
		/// </summary>
		[JsonIgnore]
		public List<QuestionAnswers> Questions { get; set; }
		/// <summary>
		/// Результаты тестов в которых участвовал ответ.
		/// </summary>
		[JsonIgnore]
		public List<TestingResult> TestingResults { get; set; }
	}
}