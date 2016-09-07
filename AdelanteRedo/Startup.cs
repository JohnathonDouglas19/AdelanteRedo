using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdelanteRedo.Startup))]
namespace AdelanteRedo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
