using Cdiscount.OpenApi.ProxyClient.Contract.Data;
using System;
using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Response
{
    /// <summary>
    /// Cart content message
    /// </summary>
    public class GetCartResponse : BaseResponseMessage
    {
        /// <summary>
        /// Cart identifier
        /// </summary>
        public Guid CartGuid { get; set; }

        /// <summary>
        /// Url to checkout order
        /// </summary>
        public string CheckoutUrl { get; set; }

        /// <summary>
        /// Cart creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Cart content items
        /// </summary>
        public CartItemList Items { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Cart total price
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Item quantity
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Cart update date
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Error type
        /// </summary>
        public string ErrorType { get; set; }
    }
}
