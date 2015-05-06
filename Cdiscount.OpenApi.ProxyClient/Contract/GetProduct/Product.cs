using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Product details
    /// </summary>
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ean { get; set; }

        public string Brand { get; set; }

        public string MainImageUrl { get; set; }

        public int Rating { get; set; }

        public int OffersCount { get; set; }

        public ProductOffer BestOffer { get; set; }

        public List<ProductImage> Images { get; set; }

        public List<ProductOffer> Offers { get; set; }

        public List<Product> AssociatedProducts { get; set; }
    }
}
