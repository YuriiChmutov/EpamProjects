﻿////using Ninject;
//using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EpamPractice.Util;
//using Ninject.Web.Mvc;
//using Ninject.Web.WebApi;

namespace EpamPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           // NinjectModule registrations = new NinjectRegistrations();
           // var kernel = new StandardKernel(registrations);
           // DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
