using Library.Service.Inventory.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Inventory
{
    public class AppsettingInventoryReadDBConnectionStringProvider : IInventoryReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingInventoryReadDBConnectionStringProvider()
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
                return _configuration["InventoryReadDBConnectionString"];
            }
        }
    }

    public class AppsettingInventoryWriteDBConnectionStringProvider : IInventoryWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingInventoryWriteDBConnectionStringProvider()
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
                return _configuration["InventoryWriteDBConnectionString"];
            }
        }
    }
}