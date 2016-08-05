using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.Mvc5.Startup))]
namespace Demo.Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
