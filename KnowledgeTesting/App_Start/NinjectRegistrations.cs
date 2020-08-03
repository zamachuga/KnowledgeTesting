using KnowledgeTesting.BL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTesting.App_Start
{
	public class NinjectRegistrations : NinjectModule
	{
		public override void Load()
		{
			Bind<IAnswerManagement>().ToMethod(x => AnswerManagement.Instance());
			Bind<IInterviweeManagement>().ToMethod(x => InterviweeManagement.Instance());
			Bind<IQuestionManagement>().ToMethod(x => QuestionManagement.Instance());
			Bind<IStatistic>().ToMethod(x => Statistic.Instance());
		}
	}
}