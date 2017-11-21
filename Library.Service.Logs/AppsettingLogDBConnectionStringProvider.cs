using Library.Infrastructure.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Logs
{
    public class AppsettingLogDBConnectionStringProvider : ILogDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingLogDBConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return _configuration["logDBConnectionString"];
            }
        }
    }
}
