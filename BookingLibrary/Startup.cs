using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using Autofac;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace BookingLibrary
{
    public class Startup
    {
        private const string SearchPath = "Services";
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc();

            var builder = new ContainerBuilder();

            var searchFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SearchPath);

            foreach (var file in Directory.EnumerateFiles(searchFolder, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    var exportedTypes = assembly.GetExportedTypes();

                    if (exportedTypes.Any(t => t.IsSubclassOf(typeof(Controller))))
                    {
                        mvcBuilder.AddApplicationPart(assembly);

                        Console.WriteLine("Started service " + assembly.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            mvcBuilder.AddControllersAsServices();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();
            return this.ApplicationContainer.Resolve<IServiceProvider>();
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



        private void BuildControllers(ContainerBuilder builder)
        {

            var searchFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SearchPath);

            foreach (var file in Directory.EnumerateFiles(searchFolder, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    var exportedTypes = assembly.GetExportedTypes();

                    if (exportedTypes.Any(t => t.IsSubclassOf(typeof(Controller))))
                    {



                        builder.RegisterAssemblyTypes(assembly).PropertiesAutowired();


                        Console.WriteLine("Started service " + assembly.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
