using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BookLibrary.Infrastructure.InjectionFramework;
using BookLibrary.Infrastructure.Messaging.RabbitMQ;
using BookLibrary.Domain.Core.Messaging;
using Microsoft.Extensions.DependencyInjection;
using BookLibrary.Service.Identity.Domain;
using BookLibrary.Service.Identity.Domain.DataAccessors;
using BookLibrary.Infrastructure.DataPersistence.Identity.SQLServer;

namespace BookLibrary.Service.Identity
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
            InjectContainer.RegisterType<IPasswordHasher, PlainTextPasswordHasher>();
            InjectContainer.RegisterType<IIdentityReadDBConnectionStringProvider, AppsettingRepositoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityWriteDBConnectionStringProvider, AppsettingRepositoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityReportDataAccessor, IdentityReportDataAccessor>();
        }
    }
}
