using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookingLibrary.UI.Utilities
{
    public class ApiRequestWithFormUrlEncodedContent
    {
        private static readonly HttpClient _httpClient;

        static ApiRequestWithFormUrlEncodedContent()
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

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }

            return result;
        }

        public static T Post<T>(string url, NameValueCollection data)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new FormUrlEncodedContent(Correct(data));
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

        public static T Put<T>(string url, NameValueCollection data)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new FormUrlEncodedContent(Correct(data));
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

        public static void Delete(string url, object data)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data));
            HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;
        }

        private static IEnumerable<KeyValuePair<string, string>> Correct(NameValueCollection formData)
        {
            return formData.Keys.Cast<string>().Select(key => new KeyValuePair<string, string>(key, formData[key])).ToList();
        }
    }
}