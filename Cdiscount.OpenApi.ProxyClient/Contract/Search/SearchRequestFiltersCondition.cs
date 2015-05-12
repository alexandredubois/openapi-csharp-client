using System.Runtime.Serialization;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public enum SearchRequestFiltersCondition
    {
        [EnumMember(Value = "new")]
        New,

        [EnumMember(Value = "used")]
        Used,

        [EnumMember(Value = "all")]
        All
    }
}