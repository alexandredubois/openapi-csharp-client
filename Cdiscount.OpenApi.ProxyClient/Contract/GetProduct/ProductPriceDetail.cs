namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Product price detail
    /// </summary>
    public class ProductPriceDetail
    {
        /// <summary>
        /// Reference price
        /// </summary>
        public decimal ReferencePrice { get; set; }

        /// <summary>
        /// Saving informations
        /// </summary>
        public ProductPriceSaving Saving { get; set; }

        /// <summary>
        /// Discount informations
        /// </summary>
        public ProductPriceDiscount Discount { get; set; }
    }
}
