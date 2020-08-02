﻿using KnowledgeTesting.BL;
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
		}
	}
}