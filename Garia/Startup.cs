using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Garia.Startup))]
namespace Garia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
