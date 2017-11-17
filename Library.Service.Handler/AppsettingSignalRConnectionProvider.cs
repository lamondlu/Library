using  Library.Infrastructure.Messaging.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace  Library.Service.Handler
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
