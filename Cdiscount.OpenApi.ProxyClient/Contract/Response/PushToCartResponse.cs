using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Response
{
    /// <summary>
    /// PushToCart response message
    /// </summary>
    public class PushToCartResponse : BaseResponseMessage
    {
        /// <summary>
        /// Cart identifier
        /// </summary>
        public Guid CartGuid { get; set; }

        /// <summary>
        /// URL to checkout
        /// </summary>
        public string CheckoutUrl { get; set; }

        /// <summary>
        /// Error Type
        /// </summary>
        public string ErrorType { get; set; }
    }
}
