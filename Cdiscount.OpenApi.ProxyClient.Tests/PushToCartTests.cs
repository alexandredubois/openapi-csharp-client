using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public async Task PushToCart_AddItemCreatingNewCart_OperationSuccess()
        {
            var response = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
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
        public async Task PushToCart_AddItemToExistingCart_OperationSuccess()
        {
            var cart = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
            {
                ProductId = "fincpangfirrnoir",
                OfferId = "fincpangfirrnoir",
                Quantity = 1,
                SellerId = 0,
                SizeId = null
            });

            var response = await _openApiProxyClient.PushToCartAsync(new PushToCartRequest
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

        [TestMethod]
        public async Task PushToCart_AddItemMkp_OperationSuccess()
        {
            var productResponse = await _openApiProxyClient.GetProductAsync(new GetProductRequest
            {
                ProductIdList = new List<string> { "nikd52001855vr2" },
                Scope = new GetProductRequestScope
                {
                    Ean = true,
                    Offers = true
                }
            });

            Assert.IsTrue(productResponse.OperationSuccess);
            Assert.IsTrue(productResponse.Products != null && productResponse.Products.Any());

            var product = productResponse.Products.First();
            var offer = product.Offers.First(o => o.Seller.Id > 0);

            var response = await _openApiProxyClient.PushToCartAsync(null, product, offer);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.AreEqual("NoError", response.ErrorType);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.CartGuid);
            Assert.IsNotNull(response.CheckoutUrl);
        }

        [TestMethod]
        public async Task PushToCart_AddItemMkpWithVariant_OperationSuccess()
        {
            var productResponse = await _openApiProxyClient.GetProductAsync(new GetProductRequest
            {
                ProductIdList = new List<string> { "mp02814077" },
                Scope = new GetProductRequestScope
                {
                    Ean = true,
                    Offers = true
                }
            });

            Assert.IsTrue(productResponse.OperationSuccess);
            Assert.IsTrue(productResponse.Products != null && productResponse.Products.Any());

            var product = productResponse.Products.First();
            var offer = product.Offers.First(o => o.Seller.Id > 0);

            var response = await _openApiProxyClient.PushToCartAsync(null, product, offer, offer.Sizes.First(s => s.IsAvailable));

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.AreEqual("NoError", response.ErrorType);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.CartGuid);
            Assert.IsNotNull(response.CheckoutUrl);
        }
    }
}
