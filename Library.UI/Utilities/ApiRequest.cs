using Newtonsoft.Json;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Utilities
{
	public class ApiRequest
	{
		private static readonly HttpClient _httpClient;

		static ApiRequest()
		{
			_httpClient = new HttpClient();
			_httpClient.Timeout = new TimeSpan(0, 0, 10);
			_httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
		}

		public static T Get<T>(string url)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}

			HttpResponseMessage response = _httpClient.GetAsync(url).Result;

			Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).Retry(2).Execute(() =>
			{
				response = _httpClient.GetAsync(url).Result;
				return response;
			});

			T result = default(T);

			if (response.IsSuccessStatusCode)
			{
				Task<string> t = response.Content.ReadAsStringAsync();
				string s = t.Result;

				result = JsonConvert.DeserializeObject<T>(s);
			}

			return result;
		}

		public static T Post<T>(string url, object data)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.PostAsync(url, httpContent).Result;

			Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).Retry(2).Execute(() =>
			{
				response = _httpClient.PostAsync(url, httpContent).Result;
				return response;
			});

			T result = default(T);

			if (response.IsSuccessStatusCode)
			{
				Task<string> t = response.Content.ReadAsStringAsync();
				string s = t.Result;

				result = JsonConvert.DeserializeObject<T>(s);
			}

			return result;
		}

		public static T Put<T>(string url, object data)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.PutAsync(url, httpContent).Result;

			Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).Retry(2).Execute(() =>
			{
				response = _httpClient.PutAsync(url, httpContent).Result;
				return response;
			});

			T result = default(T);

			if (response.IsSuccessStatusCode)
			{
				Task<string> t = response.Content.ReadAsStringAsync();
				string s = t.Result;

				result = JsonConvert.DeserializeObject<T>(s);
			}

			return result;
		}

		public static void Delete(string url, object data)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;

			Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).Retry(2).Execute(() =>
			{
				response = _httpClient.DeleteAsync(url).Result;
				return response;
			});
		}

		public static T Delete<T>(string url)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
			}

			HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;

			Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).Retry(2).Execute(() =>
			{
				response = response = _httpClient.DeleteAsync(url).Result;
				return response;
			});

			T result = default(T);

			if (response.IsSuccessStatusCode)
			{
				Task<string> t = response.Content.ReadAsStringAsync();
				string s = t.Result;

				result = JsonConvert.DeserializeObject<T>(s);
			}

			return result;
		}
	}
}