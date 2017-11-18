using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Library.Service.Identity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build();
    }
}