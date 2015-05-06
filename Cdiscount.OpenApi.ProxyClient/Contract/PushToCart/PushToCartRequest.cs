using System;
using Newtonsoft.Json;

namespace Cdiscount.OpenApi.ProxyClient.Contract.PushToCart
{
    /// <summary>
    /// Request message to add something to cart
    /// </summary>
    public class PushToCartRequest
    {
        /// <summary>
        /// Cart identifier
        /// </summary>
        /// <remarks>Used to update en existing cart.</remarks>
        [JsonProperty(PropertyName = "CartGUID")]
        public Guid? CartGuid { get; set; }

        /// <summary>
        /// Product identifier
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Offer identifier
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Quantity to add
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Seller identifier
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Size identifier
        /// </summary>
        public string SizeId { get; set; }
    }
}
