using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    /// <summary>
    /// Product shipping information
    /// </summary>
    public class ProductShipping
    {
        /// <summary>
        /// Shipping carrier name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Shipping delay to display
        /// </summary>
        public string DelayToDisplay { get; set; }
        /// <summary>
        /// Shipping price (in euros)
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Maximum delivery date
        /// </summary>
        public DateTime MaxDeliveryDate { get; set; }
        
        /// <summary>
        /// Minimum delivery date
        /// </summary>
        public DateTime MinDeliveryDate { get; set; }
    }
}
