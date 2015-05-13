using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchRequestFilters
    {
        public SearchRequestFiltersPrice Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SearchRequestFiltersNavigation Navigation { get; set; }

        public bool IncludeMarketPlace { get; set; }

        [JsonConverter(typeof(ToLowerCaseStringEnumerableConverter))]
        public string Brands { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SearchRequestFiltersCondition Condition { get; set; }
    }
}