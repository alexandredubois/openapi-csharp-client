using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Common;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
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
        /// Generic method used to send a request to the Api
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="requestMessage">Request Message</param>
        /// <returns>Request response message</returns>
        private static T Post<T>(string requestUri, object requestMessage) where T : BaseResponseMessage
        {
            T result;
            var jsonObject = JsonConvert.SerializeObject(requestMessage);

            using (var httpClient = new BaseHttpClient())
            using (var content = new BaseHttpContent(jsonObject))
            using (HttpResponseMessage response = httpClient.PostAsync(requestUri, content).Result)
            {
                response.EnsureSuccessStatusCode();
                Task<string> responseBody = response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(responseBody.Result);
                result.OperationSuccess = true;
            }

            return result;
        }

        /// <summary>
        /// Method used to add an item to a (new) cart
        /// </summary>
        /// <param name="request">Request parameters</param>
        /// <returns>Cart reference</returns>
        public PushToCartResponse PushToCart(PushToCartRequest request)
        {
            var requestMessage = new PushToCartRequestWrapper
            {
                ApiKey = _configuration.ApiKey,
                PushToCartRequest = request
            };

            return Post<PushToCartResponse>("OpenApi/json/PushToCart", requestMessage);
        }

        /// <summary>
        /// Retrieve a cart with all its details
        /// </summary>
        /// <param name="request">Cart to retrieve</param>
        /// <returns>Cart content</returns>
        public GetCartResponse GetCart(GetCartRequest request)
        {
            var requestMessage = new GetCartRequestWrapper
            {
                ApiKey = _configuration.ApiKey,
                CartRequest = request
            };

            return Post<GetCartResponse>("OpenApi/json/GetCart", requestMessage);
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var requestMessage = new GetProductRequestWrapper()
            {
                ApiKey = _configuration.ApiKey,
                ProductRequest = request
            };

            return Post<GetProductResponse>("OpenApi/json/GetProduct", requestMessage);
        }

        public SearchResponse Search(SearchRequest request)
        {
            if (request != null && request.Pagination == null)
            {
                request.Pagination = new SearchRequestPagination();
            }

            var requestMessage = new SearchRequestWrapper()
            {
                ApiKey = _configuration.ApiKey,
                SearchRequest = request
            };

            return Post<SearchResponse>("OpenApi/json/Search", requestMessage);
        }
    }
}
