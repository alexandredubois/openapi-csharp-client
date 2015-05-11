using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Product details
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product ean
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Product brand name
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Main image URL
        /// </summary>
        public string MainImageUrl { get; set; }

        /// <summary>
        /// Public rating
        /// </summary>
        public decimal? Rating { get; set; }

        /// <summary>
        /// Offer count for this product
        /// </summary>
        public int OffersCount { get; set; }

        /// <summary>
        /// Best product offer (usually, the best price for this product)
        /// </summary>
        public ProductOffer BestOffer { get; set; }

        /// <summary>
        /// Product alternatives images
        /// </summary>
        public List<ProductImage> Images { get; set; }

        /// <summary>
        /// Product offer list
        /// </summary>
        public List<ProductOffer> Offers { get; set; }

        /// <summary>
        /// Associated product list
        /// </summary>
        public List<Product> AssociatedProducts { get; set; }
    }
}
