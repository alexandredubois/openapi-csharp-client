using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

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
                ApiKey = TestsHelper.GetCdiscountOpenApiKey()
            });
        }

        [TestMethod]
        public async Task GetCartAsync_CartWith1Product_OperationSuccess()
        {
            var preparedCart = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            var response = await _openApiProxyClient.GetCartAsync(new GetCartRequest
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

        [TestMethod]
        public async Task GetCartAsync_CartWith2Products_OperationSuccess()
        {
            var preparedCart = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
            {
                CartGuid = preparedCart.CartGuid,
                ProductId = "has321011",
                OfferId = "has321011",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            var response = await _openApiProxyClient.GetCartAsync(new GetCartRequest
            {
                CartGuid = preparedCart.CartGuid
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(preparedCart.CartGuid, response.CartGuid);
            Assert.AreEqual(preparedCart.CheckoutUrl, response.CheckoutUrl);
            Assert.AreEqual(2, response.ProductCount);
            Assert.AreEqual(2, response.TotalQuantity);
            Assert.IsTrue(response.TotalPrice > 0);
            Assert.AreNotEqual(response.CreationDate, DateTime.MinValue);
            Assert.AreNotEqual(response.UpdateDate, DateTime.MinValue);
        }

        [TestMethod]
        public void GetCart_CartWith1Product_OperationSuccess()
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

        [TestMethod]
        public void GetCart_CartWith2Products_OperationSuccess()
        {
            var preparedCart = _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            _openApiProxyClient.PushToCart(new PushToCartRequest
            {
                CartGuid = preparedCart.CartGuid,
                ProductId = "has321011",
                OfferId = "has321011",
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
            Assert.AreEqual(2, response.ProductCount);
            Assert.AreEqual(2, response.TotalQuantity);
            Assert.IsTrue(response.TotalPrice > 0);
            Assert.AreNotEqual(response.CreationDate, DateTime.MinValue);
            Assert.AreNotEqual(response.UpdateDate, DateTime.MinValue);
        }
    }
}
