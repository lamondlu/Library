using Library.Domain.Core;
using Library.Service.Identity.Domain.DataAccessors;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Rental.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Handler
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
				return _configuration["inventoryReadDBConnectionString"];
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
				return _configuration["inventoryWriteDBConnectionString"];
			}
		}
	}

	public class AppsettingRentalReadDBConnectionStringProvider : IRentalReadDBConnectionStringProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppsettingRentalReadDBConnectionStringProvider()
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
				return _configuration["rentalReadDBConnectionString"];
			}
		}
	}

	public class AppsettingRentalWriteDBConnectionStringProvider : IRentalWriteDBConnectionStringProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppsettingRentalWriteDBConnectionStringProvider()
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
				return _configuration["rentalWriteDBConnectionString"];
			}
		}
	}

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

    public class AppsettingIdentityReadDBConnectionStringProvider : IIdentityReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingIdentityReadDBConnectionStringProvider()
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

    public class AppsettingIdentityWriteDBConnectionStringProvider : IIdentityWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingIdentityWriteDBConnectionStringProvider()
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