using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyDogs.Startup))]
namespace FamilyDogs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
