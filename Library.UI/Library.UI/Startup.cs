using Library.UI.SessionStorages;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.UI.Startup))]
namespace Library.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
