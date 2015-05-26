using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.GetProduct;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cdiscount.OpenApi.ProxyClient.Tests
{
    [TestClass]
    public class GetProductTests
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
        public void GetProduct_1ProductByProductId_OperationSuccess()
        {
            var response = _openApiProxyClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> {"fincpangfirrnoir"},
                Scope = new GetProductRequestScope
                {
                    Ean = true
                }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(1, response.Products.Count);

            var product = response.Products[0];
            Assert.AreEqual("fincpangfirrnoir".ToUpper(), product.Id);
            Assert.IsFalse(string.IsNullOrEmpty(product.Ean));
        }

        [TestMethod]
        public void GetProduct_2ProductsByProductId_OperationSuccess()
        {
            var response = _openApiProxyClient.GetProduct(new GetProductRequest
            {
                ProductIdList = new List<string> { "fincpangfirrnoir", "TU03" },
                Scope = new GetProductRequestScope
                {
                    Ean = true
                }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(2, response.Products.Count);
        }
    }
}