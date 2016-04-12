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
    public class TimeoutExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitOpenApiClient_TimeoutTooBig_ArgumentOutOfRangeExceptionRaised()
        {
            OpenApiClient _openApiProxyClient = new OpenApiClient(new ProxyClientConfig
            {
                ApiKey = TestsHelper.GetCdiscountOpenApiKey(),
                Timeout = TimeSpan.MaxValue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitOpenApiClient_TimeoutTooSmall_ArgumentOutOfRangeExceptionRaised()
        {
            OpenApiClient _openApiProxyClient = new OpenApiClient(new ProxyClientConfig
            {
                ApiKey = TestsHelper.GetCdiscountOpenApiKey(),
                Timeout = TimeSpan.MinValue
            });
        }

        [TestMethod]
        public async Task InitOpenApiClient_TimeoutSmall_OperationError()
        {
            OpenApiClient _openApiProxyClient = new OpenApiClient(new ProxyClientConfig
            {
                ApiKey = TestsHelper.GetCdiscountOpenApiKey(),
                Timeout = TimeSpan.FromMilliseconds(10)
            });

            var response = await _openApiProxyClient.SearchAsync(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });

            Assert.IsNotNull(response);
            Assert.IsFalse(response.OperationSuccess);
        }
    }
}
