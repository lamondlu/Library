using Library.Infrastructure.Operation.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Operation.Consul
{
    public class ConsulServiceItem
    {
        public ConsulServiceItem()
        {
            Tags = new List<string>();
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public List<string> Tags { get; set; }

        public string Address { get; set; }

        public string Port { get; set; }

        public bool EnableTagOverride { get; set; }

        public CheckItem Check { get; set; }

        public static implicit operator ConsulServiceItem(Service service)
        {
            if (service == null)
            {
                return null;
            }

            var item = new ConsulServiceItem();
            item.ID = service.ServiceUniqueId;
            item.Name = service.ServiceName;

            if (!string.IsNullOrWhiteSpace(service.Tag))
            {
                item.Tags.Add(service.Tag);
            }

            item.Address = service.Address;
            item.Port = service.Port;
            item.EnableTagOverride = false;

            return item;
        }
    }

    public class CheckItem
    {

    }
}
