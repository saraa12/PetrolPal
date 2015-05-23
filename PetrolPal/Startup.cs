using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetrolPal.Startup))]
namespace PetrolPal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
