using Library.Infrastructure.Operation.Core.Models;
using System.Collections.Generic;

namespace Library.Infrastructure.Operation.Consul
{
	public class ConsulServiceItem
	{
		public ConsulServiceItem()
		{
			Tags = new List<string>();
		}

		public string Name { get; set; }

		public List<string> Tags { get; set; }

		public int Port { get; set; }

		public string Address{get;set;}

		public bool EnableTagOverride { get; set; }

		public static implicit operator ConsulServiceItem(Service service)
		{
			if (service == null)
			{
				return null;
			}

			var item = new ConsulServiceItem();
			item.Name = service.ServiceName;

			if (!string.IsNullOrWhiteSpace(service.Tag))
			{
				item.Tags.Add(service.Tag);
			}

			item.Port = service.Port;
			item.EnableTagOverride = false;
			item.Address = service.Address;

			return item;
		}
	}

	public class CheckItem
	{
	}
}