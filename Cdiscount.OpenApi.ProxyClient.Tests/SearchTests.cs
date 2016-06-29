using Cdiscount.OpenApi.ProxyClient.Config;
using Cdiscount.OpenApi.ProxyClient.Contract.Search;
using Cdiscount.OpenApi.ProxyClient.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

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
                ApiKey = TestsHelper.GetCdiscountOpenApiKey(),
                DebugModeEnabled = true,
                Timeout = new TimeSpan(0, 0, 5)
            });
        }

        [TestMethod]
        public async Task SearchAsync_BasicCall_OperationSuccess()
        {
            var response = await _openApiProxyClient.SearchAsync(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(response.ItemCount > 0);
        }

        [TestMethod]
        public async Task SearchAsync_ComplexeCall_OperationSuccess()
        {
            var response = await _openApiProxyClient.SearchAsync(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance,
                Pagination = new SearchRequestPagination
                {
                    ItemsPerPage = 10,
                    PageNumber = 0
                },
                Filters = new SearchRequestFilters
                {
                    Price = new SearchRequestFiltersPrice
                    {
                        Min = 0,
                        Max = 100
                    },
                    Navigation = SearchRequestFiltersNavigation.Toys,
                    IncludeMarketPlace = true,
                    Brands = "LEGO",
                    Condition = SearchRequestFiltersCondition.All
                }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(response.ItemCount > 0);
        }

        [TestMethod]
        public void Search_BasicCall_OperationSuccess()
        {
            var response = _openApiProxyClient.Search(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(response.ItemCount > 0);
        }

        [TestMethod]
        public void Search_ComplexeCall_OperationSuccess()
        {
            var response = _openApiProxyClient.Search(new SearchRequest
            {
                Keyword = "superman",
                SortBy = SearchRequestSortBy.Relevance,
                Pagination = new SearchRequestPagination
                {
                    ItemsPerPage = 10,
                    PageNumber = 0
                },
                Filters = new SearchRequestFilters
                {
                    Price = new SearchRequestFiltersPrice
                    {
                        Min = 0,
                        Max = 100
                    },
                    Navigation = SearchRequestFiltersNavigation.Toys,
                    IncludeMarketPlace = true,
                    Brands = "LEGO",
                    Condition = SearchRequestFiltersCondition.All
                }
            });

            Assert.IsNotNull(response);
            Assert.IsTrue(response.OperationSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsTrue(response.ItemCount > 0);
        }
    }
}