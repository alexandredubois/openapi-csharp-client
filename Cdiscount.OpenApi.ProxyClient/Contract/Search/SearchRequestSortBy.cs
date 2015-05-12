using System.Runtime.Serialization;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public enum SearchRequestSortBy
    {
        [EnumMember(Value = "relevance")]
        Relevance,

        [EnumMember(Value = "minprice")]
        MinPrice,

        [EnumMember(Value = "maxprice")]
        MaxPrice,

        [EnumMember(Value = "rating")]
        Rating
    }
}