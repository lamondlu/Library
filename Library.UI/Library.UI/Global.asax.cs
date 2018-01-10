using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Library.UI
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private const string REGISTER_SERVICE_URL = "v1/agent/service/register";
		private static readonly HttpClient _httpClient;

		static MvcApplication()
		{
			_httpClient = new HttpClient();
			_httpClient.Timeout = new TimeSpan(0, 0, 10);
			_httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//This is an temp code, i will convert this project to an Core Mvc project later, so it can reference the same Library.Infrastructure.Operation.Consul
			var result = RegisterToServiceDiscovery();

			if (!result)
			{
				throw new System.Exception("Web is not registered in the Consul correctly.");
			}
		}

		private bool RegisterToServiceDiscovery()
		{
			var registerURL = $"{ConfigurationManager.AppSettings["serviceDiscovery"]}/{REGISTER_SERVICE_URL}";

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new
			{
				Name = "Library Web",
				Tags = new string[] { "Web" },
				Port = 81,
				EnableTagOverride = false
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.PutAsync(registerURL, httpContent).Result;

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			return false;
		}

	}
}