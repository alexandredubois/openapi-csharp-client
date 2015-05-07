﻿using Cdiscount.OpenApi.ProxyClient.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using Cdiscount.OpenApi.ProxyClient.Contract.GetCart;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Contract.PushToCart;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class GetProductRequestTests
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
        public void GetProduct_1ProductByProductId_OperationSuccess()
        {
            var response = _openApiProxyClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> { "fincpangfirrnoir" },
                Scope = new GetProductRequestScope
                {
                    Ean = true
                }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(1, response.Products.Count);
        }

    }
}
