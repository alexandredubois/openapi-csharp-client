using Cdiscount.OpenApi.ProxyClient.Contract.Common;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchResponse : BaseResponseMessage
    {
        public int ItemCount { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }
    }
}