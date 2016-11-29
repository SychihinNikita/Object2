using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.WEB.Startup))]
namespace WebUI.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
