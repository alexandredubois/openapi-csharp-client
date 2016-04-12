using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Exception;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class MissingApiKeyExceptionTests
    {
        private OpenApiClient _openApiProxyClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _openApiProxyClient = new OpenApiClient(new ProxyClientConfig
            {
                ApiKey = null
            });
        }

        [TestMethod]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task GetProduct_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = await _openApiProxyClient.GetProductAsync(new GetProductRequest
            {
                ProductIdList = new List<string> { "fincpangfirrnoir" },
                Scope = new GetProductRequestScope
                {
                    Ean = true
                }
            });
        }

        [TestMethod]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task GetCart_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = await _openApiProxyClient.GetCartAsync(new GetCartRequest
            {
                CartGuid = Guid.NewGuid()
            });
        }

        [TestMethod]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task PushToCart_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });
        }

        [TestMethod]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task Search_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = await _openApiProxyClient.SearchAsync(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });
        }
    }
}
