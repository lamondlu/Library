using Library.Domain.Core.Messaging;
using Library.Infrastructure.DataPersistence.Inventory.SQLServer;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Messaging.RabbitMQ;
using Library.Infrastructure.Messaging.SignalR;
using Library.Service.Inventory.Domain.DataAccessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Service.Inventory
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            InjectService();

            services.AddMvcCore().AddAuthorization().AddJsonFormatters();

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5001";
                options.RequireHttpsMetadata = false;
                options.ApiName = "inventoryService";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(r =>
            {
                r.MapRoute("default", "api/{controller}/{id?}");
            });
        }

        private void InjectService()
        {
            InjectContainer.RegisterType<IRabbitMQUrlProvider, AppsettingRabbitMQUrlProvider>();
            InjectContainer.RegisterType<ICommandPublisher, RabbitMQCommandPublisher>();
            InjectContainer.RegisterType<IInventoryReadDBConnectionStringProvider, AppsettingInventoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryWriteDBConnectionStringProvider, AppsettingInventoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryReportDataAccessor, InventoryReportDataAccessor>();
            InjectContainer.RegisterType<ICommandTracker, SignalRCommandTracker>();
        }
    }
}