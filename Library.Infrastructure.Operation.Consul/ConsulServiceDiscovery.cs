using Library.Infrastructure.Operation.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Infrastructure.Operation.Core.Models;
using System.Net.Http;

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

            ApiRequest.Put(registerURL, item);
        }
    }
}
