using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CusMng.Startup))]
namespace CusMng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
