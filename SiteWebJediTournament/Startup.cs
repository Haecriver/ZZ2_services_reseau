using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteWebJediTournament.Startup))]
namespace SiteWebJediTournament
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
