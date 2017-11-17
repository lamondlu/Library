using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using  Library.Infrastructure.InjectionFramework;
using  Library.Infrastructure.Messaging.RabbitMQ;
using  Library.Domain.Core.Messaging;
using Microsoft.Extensions.DependencyInjection;
using  Library.Service.Inventory.Domain.DataAccessors;
using  Library.Infrastructure.DataPersistence.Inventory.SQLServer;
using  Library.Infrastructure.Messaging.SignalR;

namespace  Library.Service.Inventory
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            InjectService();
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
            InjectContainer.RegisterInstance<ICommandPublisher>(new RabbitMQCommandPublisher("amqp://localhost:5672"));
            InjectContainer.RegisterType<IInventoryReadDBConnectionStringProvider, AppsettingInventoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryWriteDBConnectionStringProvider, AppsettingInventoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryReportDataAccessor, InventoryReportDataAccessor>();
            InjectContainer.RegisterType<ICommandTracker, SignalRCommandTracker>();
        }
    }
}
