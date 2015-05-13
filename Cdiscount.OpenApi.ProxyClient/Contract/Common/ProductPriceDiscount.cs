using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    /// <summary>
    /// Product price discount
    /// </summary>
    public class ProductPriceDiscount
    {
        /// <summary>
        /// Discount type
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Discount start date
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Discount end date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}