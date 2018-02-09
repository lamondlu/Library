using Library.Domain.Core.DataAccessor;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Handler
{
	public class AppSettingEventDBConnectionStringProvider : IEventDBConnectionStringProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppSettingEventDBConnectionStringProvider()
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
				return _configuration["connectionString"];
			}
		}
	}
}