using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Utilities
{
    public class ApiRequestWithStringContent
    {
        private static readonly HttpClient _httpClient;
        private static readonly string _identityServer = string.Empty;
        private static readonly string _clientId = string.Empty;
        private static readonly string _clientSecret = string.Empty;

        static ApiRequestWithStringContent()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = new TimeSpan(0, 0, 10);
            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

            _identityServer = ConfigurationManager.AppSettings["identityServer"];
            _clientId = ConfigurationManager.AppSettings["identityClientID"];
            _clientSecret = ConfigurationManager.AppSettings["identityClientSecret"];
        }

        public static string GetToken(string serviceName)
        {
            var disco = DiscoveryClient.GetAsync(_identityServer).Result;
            var tokenClient = new TokenClient(disco.TokenEndpoint, _clientId, _clientSecret);
            return tokenClient.RequestClientCredentialsAsync(serviceName).Result.AccessToken;
        }

        public static T Get<T>(string serviceName, string url)
        {
            _httpClient.SetBearerToken(GetToken(serviceName));

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpResponseMessage response = _httpClient.GetAsync(url).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        public static T Post<T>(string serviceName, string url, object data)
        {
            _httpClient.SetBearerToken(GetToken(serviceName));

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(url, httpContent).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        public static T Put<T>(string serviceName, string url, object data)
        {
            _httpClient.SetBearerToken(GetToken(serviceName));

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(url, httpContent).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        public static void Delete(string serviceName, string url, object data)
        {
            _httpClient.SetBearerToken(GetToken(serviceName));

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;
        }

        public static T Delete<T>(string serviceName, string url)
        {
            _httpClient.SetBearerToken(GetToken(serviceName));

            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;

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