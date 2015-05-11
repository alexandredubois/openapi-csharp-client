namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Product price saving details
    /// </summary>
    public class ProductPriceSaving
    {
        /// <summary>
        /// Saving details (amount or ratio)
        /// </summary>
        public decimal Type { get; set; }

        /// <summary>
        /// Saving value
        /// </summary>
        public string Value { get; set; }
    }
}