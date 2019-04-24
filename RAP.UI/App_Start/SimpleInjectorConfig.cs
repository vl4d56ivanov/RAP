using SimpleInjector;
using RAP.Domain.Interfaces;
using RAP.Domain.Repositories;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using RAP.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using SimpleInjector.Integration.Web;
using System.Reflection;
using SimpleInjector.Lifestyles;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SimpleInjector.Advanced;
using System.Collections.Generic;

namespace RAP.UI
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
          
            // Select the scoped lifestyle that is appropriate for the application
            // you are building. For instance:
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // !!!!implements IDisposable
            container.Register<IUnitOfWork, EFUnitOfWork>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(
                                () => new UserStore<ApplicationUser>(), Lifestyle.Scoped);   

            container.Register<IAuthenticationManager>(
                                () => HttpContext.Current.GetOwinContext().Authentication);
            
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}