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

namespace BookingLibrary
{
    public class Startup
    {
        private const string SearchPath = "Services";
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();

            BuildControllers(builder);

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();

            app.UseMvcWithDefaultRoute();


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
                        Console.WriteLine("Started service " + assembly.FullName);

                        foreach (var t in exportedTypes.Where(t => t.IsSubclassOf(typeof(Controller))))
                        {
                            builder.RegisterType(t).AsSelf();
                        }

                    }
                }
                catch { }
            }
        }
    }
}
