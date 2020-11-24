using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JJAutos.Startup))]
namespace JJAutos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
