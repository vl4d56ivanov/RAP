using RAP.Api.App_Start;
using System.Web.Http;

namespace RAP.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            MapperConfig.RegisterMapper();
        }
    }
}
