using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Request
{
    /// <summary>
    /// GetCart request object
    /// </summary>
    public class GetCartRequest
    {
        /// <summary>
        /// Cart identifier
        /// </summary>
        public Guid CartGUID { get; set; }
    }
}
