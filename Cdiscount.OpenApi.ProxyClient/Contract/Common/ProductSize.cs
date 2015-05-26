namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    /// <summary>
    /// product size entity
    /// </summary>
    public class ProductSize
    {
        /// <summary>
        /// Size identifier
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Size name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Sale price (in euros)
        /// </summary>
        public decimal SalePrice { get; set; }
        
        /// <summary>
        /// True if the size is available
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}