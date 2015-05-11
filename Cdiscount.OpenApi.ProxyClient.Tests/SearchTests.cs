using Cdiscount.OpenApi.ProxyClient.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class SearchTests
    {
        private OpenApiClient _openApiProxyClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _openApiProxyClient = new OpenApiClient(new ProxyClientConfig
            {
                ApiKey = ConfigurationManager.AppSettings["ApiKey"]
            });
        }

        [TestMethod]
        public void Search_BasicCall_OperationSuccess()
        {
            var response = _openApiProxyClient.Search(new SearchRequest
            {
                Keyword = "superman"
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
        }

    }
}
