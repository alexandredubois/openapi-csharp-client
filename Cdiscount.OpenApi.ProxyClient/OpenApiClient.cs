﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Request;
using Cdiscount.OpenApi.ProxyClient.Contract.Response;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient
{
    /// <summary>
    /// Proxy client to interact with the Cdiscount OpenApi
    /// </summary>
    public class OpenApiClient
    {
        /// <summary>
        /// Configuration setting used for remote calls
        /// </summary>
        private ProxyClientConfig _configuration;

        /// <summary>
        /// Create a proxy for the Cdiscount api
        /// </summary>
        /// <param name="configuration">Configuration setting</param>
        public OpenApiClient(ProxyClientConfig configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method used to add an item to a (new) cart
        /// </summary>
        /// <param name="request">Request parameters</param>
        /// <returns>Cart reference</returns>
        public PushToCartResponse PushToCart(PushToCartRequest request)
        {
            string baseAddress = "https://api.cdiscount.com/";
            var requestMessage = new PushToCartRequestWrapper
            {
                ApiKey = _configuration.ApiKey,
                PushToCartRequest = request
            };

            PushToCartResponse result;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonObject = JsonConvert.SerializeObject(requestMessage);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = httpClient.PostAsync("OpenApi/json/PushToCart", content).Result;

                response.EnsureSuccessStatusCode();
                Task<string> responseBody = response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<PushToCartResponse>(responseBody.Result);
                result.OperationSuccess = true;
            }

            return result;
        }
    }
}