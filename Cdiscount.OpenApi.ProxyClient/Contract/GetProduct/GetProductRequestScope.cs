namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Additional product information to retrieve
    /// </summary>
    public class GetProductRequestScope
    {
        /// <summary>
        /// Retrieve MarketPlace offers
        /// </summary>
        public bool Offers { get; set; }

        /// <summary>
        /// Retrieve associated products
        /// </summary>
        public bool AssociatedProducts { get; set; }

        /// <summary>
        /// Retrieve products images
        /// </summary>
        public bool Images { get; set; }

        /// <summary>
        /// Retrieve products ean
        /// </summary>
        public bool Ean { get; set; }
    }
}
