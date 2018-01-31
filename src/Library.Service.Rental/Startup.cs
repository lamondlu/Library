using Library.Domain.Core.Messaging;
using Library.Infrastructure.DataPersistence.Rental.SQLServer;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Messaging.RabbitMQ;
using Library.Infrastructure.Messaging.SignalR;
using Library.Infrastructure.Operation.Consul;
using Library.Infrastructure.Operation.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Service.Rental
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			InjectService();

			SelfRegister();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseStaticFiles();

			app.UseMvc(r =>
			{
				r.MapRoute("default", "api/{controller}/{id?}");
			});
		}

		public void SelfRegister()
		{
			var serviceDiscovery = InjectContainer.GetInstance<IServiceDiscovery>();
			serviceDiscovery.RegisterService(new Infrastructure.Operation.Core.Models.Service
			{
				//Port = 5002,
				ServiceName = "RentalService",
				Tag = "Microservice API"
			});

			Console.WriteLine("Register to consul successfully.");
		}

		private void InjectService()
		{
			InjectContainer.RegisterType<IRabbitMQUrlProvider, AppsettingRabbitMQUrlProvider>();
			InjectContainer.RegisterType<ICommandPublisher, RabbitMQCommandPublisher>();
			InjectContainer.RegisterType<IRentalReadDBConnectionStringProvider, AppsettingRentalReadDBConnectionStringProvider>();
			InjectContainer.RegisterType<IRentalWriteDBConnectionStringProvider, AppsettingRentalWriteDBConnectionStringProvider>();
			InjectContainer.RegisterType<IRentalReportDataAccessor, RentalReportDataAccessor>();
			InjectContainer.RegisterType<ICommandTracker, SignalRCommandTracker>();

			InjectContainer.RegisterType<IConsulAPIUrlProvider, AppsettingConsulAPIUrlProvider>();
			InjectContainer.RegisterType<IServiceDiscovery, ConsulServiceDiscovery>();
		}
	}
}