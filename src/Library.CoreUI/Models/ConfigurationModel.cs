using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.CoreUI.Models
{
    public class ConfigurationModel
    {
        public string SignalRUrl { get; set; }

        public string RedisServerIp { get; set; }

        public string RedisServerPort { get; set; }

        public string InstanceName { get; set; }

        public string ServiceDiscovery { get; set; }

        public string ApiGatewayUrl { get; set; }
    }
}
