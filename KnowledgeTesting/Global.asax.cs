using KnowledgeTesting.App_Start;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KnowledgeTesting
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Внедрение зависимостей.
			NinjectModule _Registrations = new NinjectRegistrations();
			var NinjectKernel = new StandardKernel(_Registrations);
			DependencyResolver.SetResolver(new NinjectDependencyResolver(NinjectKernel));
		}
	}
}
