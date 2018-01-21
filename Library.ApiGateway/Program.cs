using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Library.ApiGateway
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IWebHostBuilder builder = new WebHostBuilder();
			builder.ConfigureServices(s =>
			{
				s.AddSingleton(builder);
			});
			builder.UseKestrel()
				   .UseUrls("http://*:4999")
				   .UseContentRoot(Directory.GetCurrentDirectory())
				   .UseIISIntegration()
				   .UseStartup<Startup>()
				   .UseApplicationInsights();
			var host = builder.Build();
			host.Run();
		}
	}
}