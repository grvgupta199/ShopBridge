using System;
using System.Net.Http;


namespace ShopBridge.ApiServices
{

    /// <summary>
    /// 
    /// </summary>
    public class ApiService
    {
      
       static readonly string BASE_URL = System.Configuration.ConfigurationManager.AppSettings["webapiURL"];

        public static TResponse Get<TResponse>(string url) 
        {

            HttpClientHandler handler = new HttpClientHandler();

            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler, true))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(BASE_URL);
                client.Timeout = TimeSpan.FromSeconds(2400);
                var response = client.GetAsync(url).Result;
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

        }
        
        public static TResponse Post<TRequest, TResponse>(string url, TRequest content) 
        {
            HttpResponseMessage response = null;

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler, true))
            {
                client.Timeout = TimeSpan.FromSeconds(2400);
                client.BaseAddress = new Uri(BASE_URL);
                response = client.PostAsJsonAsync<TRequest>(url, content).Result;

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

}