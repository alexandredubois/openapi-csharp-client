namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    public class ProductPriceDetail
    {
        public decimal ReferencePrice { get; set; }

        public ProductPriceSaving Saving { get; set; }

        public ProductPriceDiscount Discount { get; set; }
    }
}
