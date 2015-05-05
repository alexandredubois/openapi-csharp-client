using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class PushToCartTests
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
        public void PushToCart_BasicTest_OperationSuccess()
        {
            var response = _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.AreEqual("NoError", response.ErrorType);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.CartGuid);
            Assert.IsNotNull(response.CheckoutUrl);
        }
    }
}
