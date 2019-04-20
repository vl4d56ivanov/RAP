using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAP.UI.Startup))]
namespace RAP.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
