using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DucPhamStore.Startup))]
namespace DucPhamStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
