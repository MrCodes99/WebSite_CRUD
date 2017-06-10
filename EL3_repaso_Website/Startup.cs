using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EL3_repaso_Website.Startup))]
namespace EL3_repaso_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
