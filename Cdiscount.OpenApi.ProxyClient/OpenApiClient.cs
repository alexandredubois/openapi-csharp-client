using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Common;
using Cdiscount.OpenApi.ProxyClient.Contract.Exception;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

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
        private static async Task<T> Post<T>(string requestUri, object requestMessage) where T : BaseResponseMessage
        {
            T result;
            var jsonObject = JsonConvert.SerializeObject(requestMessage);

            using (var httpClient = new BaseHttpClient())
            using (var content = new BaseHttpContent(jsonObject))
            {
                HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);
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
            CheckConfiguration();
            return PushToCartAsync(request).Result;
        }

        /// <summary>
        /// Method used to add an item to a (new) cart (async method)
        /// </summary>
        /// <param name="request">Request parameters</param>
        /// <returns>Cart reference</returns>
        public async Task<PushToCartResponse> PushToCartAsync(PushToCartRequest request)
        {
            CheckConfiguration();
            var requestMessage = new PushToCartRequestWrapper
            {
                ApiKey = _configuration.ApiKey,
                PushToCartRequest = request
            };

            return await Post<PushToCartResponse>("OpenApi/json/PushToCart", requestMessage);
        }

        /// <summary>
        /// Retrieve a cart with all its details
        /// </summary>
        /// <param name="request">Cart to retrieve</param>
        /// <returns>Cart content</returns>
        public GetCartResponse GetCart(GetCartRequest request)
        {
            CheckConfiguration();
            return GetCartAsync(request).Result;
        }

        /// <summary>
        /// Retrieve a cart with all its details (async method)
        /// </summary>
        /// <param name="request">Cart to retrieve</param>
        /// <returns>Cart content</returns>
        public async Task<GetCartResponse> GetCartAsync(GetCartRequest request)
        {
            CheckConfiguration();
            var requestMessage = new GetCartRequestWrapper
            {
                ApiKey = _configuration.ApiKey,
                CartRequest = request
            };

            return await Post<GetCartResponse>("OpenApi/json/GetCart", requestMessage);
        }

        /// <summary>
        /// Retrieve a product with all its details
        /// </summary>
        /// <param name="request">Product(s) to retrieve</param>
        /// <returns>Product(s) information</returns>
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            CheckConfiguration();
            return GetProductAsync(request).Result;
        }

        /// <summary>
        /// Retrieve a product with all its details (async method)
        /// </summary>
        /// <param name="request">Product(s) to retrieve</param>
        /// <returns>Product(s) information</returns>
        public async Task<GetProductResponse> GetProductAsync(GetProductRequest request)
        {
            CheckConfiguration();
            var requestMessage = new GetProductRequestWrapper()
            {
                ApiKey = _configuration.ApiKey,
                ProductRequest = request
            };

            return await Post<GetProductResponse>("OpenApi/json/GetProduct", requestMessage);
        }

        /// <summary>
        /// Retrieve product(s) list based on your query
        /// </summary>
        /// <param name="request">Search query parameters</param>
        /// <returns>Search result</returns>
        public SearchResponse Search(SearchRequest request)
        {
            CheckConfiguration();
            return SearchAsync(request).Result;
        }

        /// <summary>
        /// Retrieve product(s) list based on your query (async method)
        /// </summary>
        /// <param name="request">Search query parameters</param>
        /// <returns>Search result</returns>
        public async Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            CheckConfiguration();
            if (request != null && request.Pagination == null)
            {
                request.Pagination = new SearchRequestPagination();
            }

            var requestMessage = new SearchRequestWrapper()
            {
                ApiKey = _configuration.ApiKey,
                SearchRequest = request
            };

            return await Post<SearchResponse>("OpenApi/json/Search", requestMessage);
        }

        private void CheckConfiguration()
        {
            if (_configuration == null || string.IsNullOrWhiteSpace(_configuration.ApiKey))
            {
                throw new MissingApiKeyException("The Cdiscount OpenApiKey is missing. Call aborted.");
            }
        }

    }
}
