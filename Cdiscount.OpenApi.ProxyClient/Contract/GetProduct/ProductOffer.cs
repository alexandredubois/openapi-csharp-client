using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Product offer entity
    /// </summary>
    public class ProductOffer
    {
        /// <summary>
        /// Offer identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Product condition (New or Used)
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// True if the product is available
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Product sheet URL on cdiscount.com website
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// Sale price (in euros)
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Informations about the seller
        /// </summary>
        public ProductSeller Seller { get; set; }

        /// <summary>
        /// Details about the price
        /// </summary>
        public ProductPriceDetail PriceDetail { get; set; }

        /// <summary>
        /// Shipping details about this offer
        /// </summary>
        public List<ProductShipping> ProductShippings { get; set; }

        /// <summary>
        /// Product sizes available
        /// </summary>
        public List<ProductSize> Sizes { get; set; }
    }
}
