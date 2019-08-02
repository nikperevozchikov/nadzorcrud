using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemNFO.Startup))]
namespace SystemNFO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
