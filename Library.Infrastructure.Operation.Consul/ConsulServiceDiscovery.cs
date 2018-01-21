using Library.Infrastructure.Operation.Core;
using Library.Infrastructure.Operation.Core.Models;
using System;

namespace Library.Infrastructure.Operation.Consul
{
	public class ConsulServiceDiscovery : BaseServiceDiscovery
	{
		private IConsulAPIUrlProvider _urlProvider = null;
		private const string REGISTER_SERVICE_URL = "v1/agent/service/register";

		public ConsulServiceDiscovery(IConsulAPIUrlProvider urlProvider)
		{
			_urlProvider = urlProvider;

			if (_urlProvider == null || string.IsNullOrEmpty(_urlProvider.Url))
			{
				throw new Exception("The consul url could not be empty.");
			}
		}

		public override void RegisterService(Service service)
		{
			var registerURL = $"{_urlProvider.Url}/{REGISTER_SERVICE_URL}";
			ConsulServiceItem item = service;

			var result = ApiRequest.Put(registerURL, item);

			if (!result)
			{
				throw new Exception("API register failure.");
			}
		}
	}
}