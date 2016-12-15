using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_ABM.Startup))]
namespace ASP_ABM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
