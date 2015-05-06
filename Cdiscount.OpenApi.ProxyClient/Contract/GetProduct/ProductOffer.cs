using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    public class ProductOffer
    {
        public string Id { get; set; }

        public string Condition { get; set; }

        public bool IsAvailable { get; set; }

        public bool ProductUrl { get; set; }

        public decimal SalePrice { get; set; }

        public ProductSeller Seller { get; set; }

        public ProductPriceDetail PriceDetail { get; set; }

        public List<ProductShipping> ProductShippings { get; set; }

        public List<ProductSize> Sizes { get; set; }
    }
}
