using System;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetCart
{
    /// <summary>
    /// GetCart request object
    /// </summary>
    public class GetCartRequest
    {
        /// <summary>
        /// Cart identifier
        /// </summary>
        [JsonProperty(PropertyName = "CartGUID")]
        public Guid CartGuid { get; set; }
    }
}
