using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XinemaProject.Startup))]
namespace XinemaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
