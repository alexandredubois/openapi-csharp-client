using Cdiscount.OpenApi.ProxyClient.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using System.Linq;

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

        [TestMethod]
        public void PushToCart_AddItemMkp_OperationSuccess()
        {
            var getProduct = _openApiProxyClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> { "nikd52001855vr2" },
                Scope = new GetProductRequestScope
                {
                    Ean = true,
                    Offers = true
                }
            });

            Assert.IsTrue(getProduct.OperationSuccess);
            Assert.IsTrue(getProduct.Products != null && getProduct.Products.Any());

            var offer = getProduct.Products[0].Offers.First(o => o.Seller.Id > 0);

            var request = new PushToCartRequest
            {
                ProductId = getProduct.Products[0].Id,
                OfferId = offer.Id,
                SellerId = offer.Seller.Id,
                Quantity = 1,
                SizeId = null
            };

            var response = _openApiProxyClient.PushToCart(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.AreEqual("NoError", response.ErrorType);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.CartGuid);
            Assert.IsNotNull(response.CheckoutUrl);
        }

        [TestMethod]
        public void PushToCart_AddItemMkpWithVariant_OperationSuccess()
        {
            var getProduct = _openApiProxyClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> { "mp02814077" },
                Scope = new GetProductRequestScope
                {
                    Ean = true,
                    Offers = true
                }
            });

            Assert.IsTrue(getProduct.OperationSuccess);
            Assert.IsTrue(getProduct.Products != null && getProduct.Products.Any());

            var offer = getProduct.Products[0].Offers.First(o => o.Seller.Id > 0);

            var request = new PushToCartRequest
            {
                ProductId = getProduct.Products[0].Id,
                OfferId = offer.Id,
                SellerId = offer.Seller.Id,
                Quantity = 1,
                SizeId = offer.Sizes.First(s => s.IsAvailable).Id
            };

            var response = _openApiProxyClient.PushToCart(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.AreEqual("NoError", response.ErrorType);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.CartGuid);
            Assert.IsNotNull(response.CheckoutUrl);
        }
    }
}
