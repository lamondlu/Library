using System;
using System.IO;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;

namespace BookingLibrary.Service.Leasing
{
    public class AppsettingLeasingReadDBConnectionStringProvider : ILeasingReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingLeasingReadDBConnectionStringProvider()
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
                return _configuration["leaseReadDBConnectionString"];
            }
        }
    }

    public class AppsettingLeasingWriteDBConnectionStringProvider : ILeasingWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingLeasingWriteDBConnectionStringProvider()
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
                return _configuration["leaseWriteDBConnectionString"];
            }
        }
    }
}