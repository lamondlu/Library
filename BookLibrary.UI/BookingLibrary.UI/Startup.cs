using BookingLibrary.UI.SessionStorages;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingLibrary.UI.Startup))]
namespace BookingLibrary.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            

            
            ConfigureAuth(app);
        }
    }
}
