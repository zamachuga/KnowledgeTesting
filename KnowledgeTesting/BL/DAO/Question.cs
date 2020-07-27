using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Web;
using DTO = KnowledgeTesting.BL.DTO;

namespace KnowledgeTesting.BL.DAO
{
	/// <summary>
	/// Вопрос.
	/// </summary>
	[DataContract]
	public class Question
	{
		public Question()
		{
			Answers = new List<QuestionAnswers>();
			Tests = new List<TestQuestions>();
			TestingResults = new List<TestingResult>();
		}

		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Text { get; set; }
		/// <summary>
		/// Вопросы.
		/// </summary>
		[JsonIgnore]
		public virtual List<QuestionAnswers> Answers { get; set; }
		/// <summary>
		/// Тесты в которых содержится вопрос.
		/// </summary>
		[JsonIgnore]
		public virtual List<TestQuestions> Tests { get; set; }
		/// <summary>
		/// Результаты прохождения тестов для вопроса.
		/// </summary>
		[JsonIgnore]
		public virtual List<TestingResult> TestingResults { get; set; }
	}
}