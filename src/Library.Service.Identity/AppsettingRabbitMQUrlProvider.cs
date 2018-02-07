using Library.Infrastructure.Messaging.RabbitMQ;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Identity
{
	public class AppsettingRabbitMQUrlProvider : IRabbitMQUrlProvider
	{
		private IConfigurationRoot _configuration = null;

		public AppsettingRabbitMQUrlProvider()
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
				return _configuration["rabbitMQUrl"];
			}
		}

		public string UserName
		{
			get
			{
				return _configuration["rabbitMQUserName"];
			}
		}

		public string Password
		{
			get
			{
				return _configuration["rabbitMQPassword"];
			}
		}
	}
}