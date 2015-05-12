using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchRequest
    {
        public string Keyword { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SearchRequestSortBy SortBy { get; set; }

        public SearchRequestPagination Pagination { get; set; }

        public SearchRequestFilters Filters { get; set; }
    }
}