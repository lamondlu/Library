using Library.Domain.Core.Messaging;
using Library.Infrastructure.DataPersistence.Identity.SQLServer;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Messaging.RabbitMQ;
using Library.Infrastructure.Operation.Consul;
using Library.Infrastructure.Operation.Core;
using Library.Service.Identity.Domain;
using Library.Service.Identity.Domain.DataAccessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Service.Identity
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

		public void SelfRegister()
		{
			var serviceDiscovery = InjectContainer.GetInstance<IServiceDiscovery>();
			serviceDiscovery.RegisterService(new Infrastructure.Operation.Core.Models.Service
			{
				Port = 5000,
				ServiceName = "IdentityService",
				Tag = "Microservice API",
				Address = "172.27.0.189"
			});

			Console.WriteLine("Register to consul successfully.");
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

		private void InjectService()
        {
            InjectContainer.RegisterType<IRabbitMQUrlProvider, AppsettingRabbitMQUrlProvider>();
			InjectContainer.RegisterType<IIdentityReadDBConnectionStringProvider, AppsettingRepositoryReadDBConnectionStringProvider>();
			InjectContainer.RegisterType<IIdentityWriteDBConnectionStringProvider, AppsettingRepositoryWriteDBConnectionStringProvider>();
			InjectContainer.RegisterType<IIdentityReportDataAccessor, IdentityReportDataAccessor>();

			InjectContainer.RegisterType<IConsulAPIUrlProvider, AppsettingConsulAPIUrlProvider>();
			InjectContainer.RegisterType<IServiceDiscovery, ConsulServiceDiscovery>();
            InjectContainer.RegisterType<ICommandPublisher, RabbitMQCommandPublisher>();
        }
	}
}