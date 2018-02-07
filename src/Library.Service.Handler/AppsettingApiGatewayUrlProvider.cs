using Library.Infrastructure.CSDataAccessor.Core;
using Library.Infrastructure.Messaging.RabbitMQ;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Handler
{
	public class AppsettingApiGatewayUrlProvider : IApiGatewayUrlProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppsettingApiGatewayUrlProvider()
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
				return _configuration["apiGatewayUrl"];
			}
		}
	}
}