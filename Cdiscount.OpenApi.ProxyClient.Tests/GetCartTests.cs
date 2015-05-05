using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class GetCartTests
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
        public void GetCart_BasicTest_OperationSuccess()
        {
            var preparedCart = _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            var response = _openApiProxyClient.GetCart(new GetCartRequest
                {
                    CartGuid = preparedCart.CartGuid
                });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(preparedCart.CartGuid, response.CartGuid);
            Assert.AreEqual(preparedCart.CheckoutUrl, response.CheckoutUrl);
            Assert.AreEqual(1, response.ProductCount);
            Assert.AreEqual(1, response.TotalQuantity);
            Assert.IsTrue(response.TotalPrice > 0);
            Assert.AreNotEqual(response.CreationDate, DateTime.MinValue);
            Assert.AreNotEqual(response.UpdateDate, DateTime.MinValue);
        }
    }
}
