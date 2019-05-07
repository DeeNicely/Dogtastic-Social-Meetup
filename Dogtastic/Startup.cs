using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dogtastic.Startup))]
namespace Dogtastic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
