using Cdiscount.OpenApi.ProxyClient.Contract.Common;
using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchResponse : BaseResponseMessage
    {
        public int ItemCount { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }

        /// <summary>
        /// Product found list
        /// </summary>
        public List<Product> Products { get; set; }
    }
}