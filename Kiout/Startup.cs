using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kiout.Startup))]
namespace Kiout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
