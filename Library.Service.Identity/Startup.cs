using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using  Library.Infrastructure.InjectionFramework;
using  Library.Infrastructure.Messaging.RabbitMQ;
using  Library.Domain.Core.Messaging;
using Microsoft.Extensions.DependencyInjection;
using  Library.Service.Identity.Domain;
using  Library.Service.Identity.Domain.DataAccessors;
using  Library.Infrastructure.DataPersistence.Identity.SQLServer;

namespace  Library.Service.Identity
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
