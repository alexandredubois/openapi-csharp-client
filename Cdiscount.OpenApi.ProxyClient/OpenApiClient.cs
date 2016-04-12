using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Common;
using Cdiscount.OpenApi.ProxyClient.Contract.Exception;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
using Newtonsoft.Json;
using System;
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
        private async Task<T> Post<T>(string requestUri, object requestMessage) where T : BaseResponseMessage, new()
        {
            T result;

            try
            {
                var jsonObject = JsonConvert.SerializeObject(requestMessage);

                using (var httpClient = new BaseHttpClient() { Timeout = _configuration.Timeout })
                using (var content = new BaseHttpContent(jsonObject))
                {
                    HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(responseBody);
                        result.OperationSuccess = true;
                    }
                    else
                    {
                        result = new T();
                        result.ErrorMessage = string.Format("StatusCode: {0}, ReasonPhrase: '{1}'", (int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new T();
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Method used to add an item to a (new) cart
        /// </summary>
        /// <param name="request">Request parameters</param>
        /// <returns>Cart reference</returns>
        [Obsolete("Use PushToCartAsync")]
        public PushToCartResponse PushToCart(PushToCartRequest request)
        {
            CheckConfiguration();
            return PushToCartAsync(request).Result;
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product)
        {
            return PushToCartAsync(cartGuid, product, 1);
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <param name="quantity">Quantity of the product to add</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product, int quantity)
        {
            return PushToCartAsync(cartGuid, product, product != null ? product.BestOffer : null, null, quantity);
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <param name="offer">Product specific offer to add to the cart</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product, ProductOffer offer)
        {
            return PushToCartAsync(cartGuid, product, offer, 1);
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <param name="offer">Product specific offer to add to the cart</param>
        /// <param name="quantity">Quantity of the product to add</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product, ProductOffer offer, int quantity)
        {
            return PushToCartAsync(cartGuid, product, offer, null, quantity);
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <param name="offer">Product specific offer to add to the cart</param>
        /// <param name="size">Specific size of the product to use (if applicable)</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product, ProductOffer offer, ProductSize size)
        {
            return PushToCartAsync(cartGuid, product, offer, size, 1);
        }

        /// <summary>
        /// Helper method to add a product to a cart
        /// </summary>
        /// <param name="cartGuid">Guid of the cart if existing. Null if creating a new cart</param>
        /// <param name="product">Product to add to the cart</param>
        /// <param name="offer">Product specific offer to add to the cart</param>
        /// <param name="size">Specific size of the product to use (if applicable)</param>
        /// <param name="quantity">Quantity of the product to add</param>
        /// <returns>Cart reference</returns>
        public Task<PushToCartResponse> PushToCartAsync(Guid? cartGuid, Product product, ProductOffer offer, ProductSize size, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "The product must not be null");
            }

            if (quantity < 1 || quantity > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "The quantity must be an integer between 1 and 12");
            }

            PushToCartRequest pushToCartRequest = new PushToCartRequest()
            {
                ProductId = product.Id,
                Quantity = quantity
            };

            if (cartGuid != Guid.Empty)
            {
                pushToCartRequest.CartGuid = cartGuid;
            }

            if (offer != null)
            {
                pushToCartRequest.OfferId = offer.Id;

                if (offer.Seller != null)
                {
                    pushToCartRequest.SellerId = offer.Seller.Id;
                }
            }

            if (size != null)
            {
                pushToCartRequest.SizeId = size.Id;
            }

            return PushToCartAsync(pushToCartRequest);
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
        [Obsolete("Use GetCartAsync")]
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
        [Obsolete("Use GetProductAsync")]
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
        [Obsolete("Use SearchAsync")]
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
