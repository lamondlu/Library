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
            app.CreatePerOwinContext<ISessionStorage>(() =>
            {
                return new RedisSessionStorage("127.0.0.1", 6379);
            });

            ConfigureAuth(app);
        }
    }
}
