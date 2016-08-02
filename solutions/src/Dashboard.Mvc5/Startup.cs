using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dashboard.Mvc5.Startup))]
namespace Dashboard.Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
