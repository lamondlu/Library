using Library.Infrastructure.Messaging.SignalR;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Library.Service.Handler
{
    public class AppsettingSignalRConnectionProvider : ISignalRConnectionProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingSignalRConnectionProvider()
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
                return _configuration["signalRUrl"];
            }
        }
    }
}