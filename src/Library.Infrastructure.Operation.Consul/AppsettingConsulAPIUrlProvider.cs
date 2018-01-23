using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Infrastructure.Operation.Consul
{
	public class AppsettingConsulAPIUrlProvider : IConsulAPIUrlProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppsettingConsulAPIUrlProvider()
		{
			var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");

			_configuration = builder.Build();
		}

		public string Url
		{
			get
			{
				return _configuration["consulUrl"];
			}
		}
	}
}