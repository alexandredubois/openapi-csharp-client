using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Contract.Data;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Request
{
    /// <summary>
    /// Request object to retrieve product(s)
    /// </summary>
    public class GetProductRequest
    {
        /// <summary>
        /// Product Identifier list
        /// </summary>
        public List<string> ProductIdList { get; set; }

        /// <summary>
        /// Product EAN  list
        /// </summary>
        [JsonProperty(PropertyName = "EANList")]
        public List<string> EanList { get; set; }

        /// <summary>
        /// Additional product information to retrieve
        /// </summary>
        public GetProductRequestScope Scope { get; set; }


    }
}
