namespace Cdiscount.OpenApi.ProxyClient.Contract.GetCart
{
    /// <summary>
    /// Cart item detail
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Product condition (new or used)
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Offer identifier
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Product unit price (in euros)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product identifier
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Seller identifier
        /// </summary>
        public int? SellerId { get; set; }

        /// <summary>
        /// Size identifier
        /// </summary>
        public string SizeId { get; set; }
    }
}
