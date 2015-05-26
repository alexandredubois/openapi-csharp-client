using Cdiscount.OpenApi.ProxyClient.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;

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
                ApiKey = TestsHelper.GetCdiscountOpenApiKey()
            });
        }

        [TestMethod]
        public void PushToCart_AddItemCreatingNewCart_OperationSuccess()
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

        [TestMethod]
        public void PushToCart_AddItemToExistingCart_OperationSuccess()
        {
            var cart = _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            var response = _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                CartGuid = cart.CartGuid,
                ProductId = "has321011",
                OfferId = "has321011",
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
            Assert.AreEqual(cart.CartGuid, response.CartGuid);
        }
    }
}
