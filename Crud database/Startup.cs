using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crud_database.Startup))]
namespace Crud_database
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
