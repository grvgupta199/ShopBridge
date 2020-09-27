using ShopBridge.Api;
using System;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.ApiServices
{

    /// <summary>
    /// 
    /// </summary>
    public class ApiService
    {
        private static ApiService _service;
        private HttpClient _httpClient;
        private HttpConfiguration _config;

        static ApiService()
        {
            if (_service == null)
            {
                _service = new ApiService();

                _service._config = new HttpConfiguration();
                WebApiConfig.Register(_service._config);
                var server = new HttpServer(_service._config);
                _service._httpClient = new HttpClient(server);
                _service._httpClient.BaseAddress = new Uri("http://routetest/api");
            }
        }

        public static TResponse Get<TResponse>(string url)
        {
            var response = _service._httpClient.GetAsync(string.Format("api/{0}",url)).Result;
            if (response.IsSuccessStatusCode == false)
            {
                return default(TResponse);
            }
            else
            {
                var data = response.Content.ReadAsAsync<TResponse>().Result;
                return data;
            }


        }

        public static TResponse Post<TRequest, TResponse>(string url, TRequest content)
        {
            var response = _service._httpClient.PostAsJsonAsync<TRequest>(string.Format("api/{0}", url), content).Result;
            if (!response.IsSuccessStatusCode)
            {
                return default(TResponse);
            }
            else
            {
                return response.Content.ReadAsAsync<TResponse>().Result; ;
            }


        }

    }


}