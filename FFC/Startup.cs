using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FFC.Startup))]
namespace FFC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
