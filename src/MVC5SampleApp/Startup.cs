using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5SampleApp.Startup))]
namespace MVC5SampleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}