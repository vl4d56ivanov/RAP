﻿using RAP.Domain.Identity;
using RAP.Domain.Util;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RAP.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //TODO: DI disabled.
            //SimpleInjectorConfig.RegisterComponents();

            Database.SetInitializer<ApplicationDbContext>(new InitializationRapDb());

            MapperConfig.RegisterMapper();

            LoggerManager.InitLogger();
        }
    }
}
