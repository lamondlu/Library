using System;
using System.IO;
using  Library.Service.Identity.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;

namespace  Library.Service.Identity
{
    public class AppsettingRepositoryReadDBConnectionStringProvider : IIdentityReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingRepositoryReadDBConnectionStringProvider()
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
                return _configuration["identityReadDBConnectionString"];
            }
        }
    }

    public class AppsettingRepositoryWriteDBConnectionStringProvider : IIdentityWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingRepositoryWriteDBConnectionStringProvider()
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
                return _configuration["identityWriteDBConnectionString"];
            }
        }
    }
}