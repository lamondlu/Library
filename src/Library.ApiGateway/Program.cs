using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library.ApiGateway
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IWebHostBuilder builder = new WebHostBuilder();
			builder.ConfigureServices(s => {
				s.AddSingleton(builder);
			});

			builder
				.UseKestrel()
				.UseUrls("http://*:4999")
				.UseContentRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
					var env = hostingContext.HostingEnvironment;
					config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
					config.AddJsonFile("configuration.json");
					config.AddEnvironmentVariables();
				})
				.ConfigureLogging((hostingContext, logging) =>
				{
					logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
					logging.AddConsole();
				})
				.UseStartup<Startup>();

			var host = builder.Build();
			host.Run();
		}
	}
}