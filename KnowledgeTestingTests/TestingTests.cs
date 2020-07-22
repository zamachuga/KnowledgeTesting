using KnowledgeTesting.BL;
using DAO = KnowledgeTesting.BL.DAO;
using KnowledgeTesting.BL.DB.PgSql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Moq;
using KnowledgeTesting.BL.DAO;
using System.Threading;

namespace KnowledgeTestingTests
{
	[TestFixture]
	class TestingTests
	{
		Testing _TestingManagement = new Testing();

		[Test]
		public void StartTest()
		{
			DbPgSqlContext _DbContext = DbPgSqlContext.Instance();
			using (var _Trns = _DbContext.Database.BeginTransaction())
			{
				Interviwee _Interviwee = new DAO.Interviwee() { FirstName = "sdad", LasName = "adasd" };
				_Interviwee = _DbContext.Interviwees.Add(_Interviwee);
				Test _Test = new DAO.Test() { Name = "sdasdasd" };
				_Test = _DbContext.Tests.Add(_Test);
				_DbContext.SaveChanges();

				InterviweeTests _Result = _TestingManagement.StartTest(_Interviwee, _Test);
				_DbContext.SaveChanges();

				Assert.True(_Result.Id > 0);

				_Trns.Rollback();
			}
		}

		[Test]
		public void RandomQuestion()
		{
			TestQuestions[] _TestQuestions = new TestQuestions[]{
				new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },
				new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },
				new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },
				new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },
				new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },new TestQuestions(){ Question = new Question() {Text = Guid.NewGuid().ToString() } },
			};

			var Q1 = _TestingManagement.RandomQuestion(_TestQuestions);
			Thread.Sleep(10);
			var Q2 = _TestingManagement.RandomQuestion(_TestQuestions);

			Assert.False(Q1?.Equals(Q2));
		}
	}
}