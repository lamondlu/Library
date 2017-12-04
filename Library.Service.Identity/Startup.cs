using Library.Infrastructure.DataPersistence.Identity.SQLServer;
using Library.Infrastructure.InjectionFramework;
using Library.Service.Identity.Domain;
using Library.Service.Identity.Domain.DataAccessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Service.Identity
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
                options.Authority = "http://localhost:5004";
                options.RequireHttpsMetadata = false;
                options.ApiName = "identityService";
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
            InjectContainer.RegisterType<IPasswordHasher, PlainTextPasswordHasher>();
            InjectContainer.RegisterType<IIdentityReadDBConnectionStringProvider, AppsettingRepositoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityWriteDBConnectionStringProvider, AppsettingRepositoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityReportDataAccessor, IdentityReportDataAccessor>();
        }
    }
}