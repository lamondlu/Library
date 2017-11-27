using Library.Domain.Core;
using Microsoft.Extensions.Configuration;
using System.IO;

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