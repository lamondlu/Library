using Microsoft.Extensions.Configuration;
using System.IO;
using Library.Infrastructure.Messaging.RabbitMQ;

namespace Library.Service.Handler
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
    }
}