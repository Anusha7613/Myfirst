using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myfirst.Startup))]
namespace Myfirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
