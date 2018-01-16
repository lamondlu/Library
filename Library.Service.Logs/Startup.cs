using Library.Domain.Core;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Logger.SQLServer;
using Library.Infrastructure.Operation.Consul;
using Library.Infrastructure.Operation.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Service.Logs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
                Port = 5003,
                ServiceName = "LogService",
                Tag = "Microservice API"
            });

            Console.WriteLine("Register to consul successfully.");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }

        private void InjectService()
        {
            InjectContainer.RegisterType<ILogDBConnectionStringProvider, AppsettingLogDBConnectionStringProvider>();
            InjectContainer.RegisterType<ILogger, Logger>();

            InjectContainer.RegisterType<IConsulAPIUrlProvider, AppsettingConsulAPIUrlProvider>();
            InjectContainer.RegisterType<IServiceDiscovery, ConsulServiceDiscovery>();
        }
    }
}