using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BookLibrary.Infrastructure.InjectionFramework;
using BookLibrary.Infrastructure.Messaging.RabbitMQ;
using BookLibrary.Domain.Core.Messaging;
using Microsoft.Extensions.DependencyInjection;
using BookLibrary.Service.Rental.Domain.DataAccessors;
using BookLibrary.Infrastructure.DataPersistence.Rental.SQLServer;
using BookLibrary.Infrastructure.Messaging.SignalR;

namespace BookLibrary.Service.Rental
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
            InjectContainer.RegisterType<IRentalReadDBConnectionStringProvider, AppsettingRentalReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalWriteDBConnectionStringProvider, AppsettingRentalWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalReportDataAccessor, RentalReportDataAccessor>();
            InjectContainer.RegisterType<ICommandTracker, SignalRCommandTracker>();
        }
    }
}
