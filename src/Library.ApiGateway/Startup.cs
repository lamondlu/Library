using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Library.ApiGateway
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddOcelot();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseOcelot().Wait();
		}
	}
}