using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    public class BaseHttpClient : HttpClient
    {
        private const string ApiAddress = "https://api.cdiscount.com/";

        public BaseHttpClient()
        {
            this.BaseAddress = new Uri(ApiAddress);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
