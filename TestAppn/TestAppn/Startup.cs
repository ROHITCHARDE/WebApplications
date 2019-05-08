using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAppn.Startup))]
namespace TestAppn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
