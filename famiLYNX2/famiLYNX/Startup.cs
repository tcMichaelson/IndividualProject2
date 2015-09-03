using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(famiLYNX.Startup))]
namespace famiLYNX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
