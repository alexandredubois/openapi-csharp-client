using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Exception;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GetProduct_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = _openApiProxyClient.GetProduct(new GetProductRequest
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
        public void GetCart_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = _openApiProxyClient.GetCart(new GetCartRequest
            {
                CartGuid = Guid.NewGuid()
            });
        }

        [TestMethod]
        [ExpectedException(typeof(MissingApiKeyException))]
        public void PushToCart_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = _openApiProxyClient.PushToCart(new PushToCartRequest
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
        public void Search_ApiKeyMissing_MissingApiKeyExceptionRaised()
        {
            var response = _openApiProxyClient.Search(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });
        }
    }
}
