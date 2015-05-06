using System.Collections.Generic;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetCart
{
    /// <summary>
    /// Cart item list
    /// </summary>
    public class CartItemList
    {
        /// <summary>
        /// Cart detail
        /// </summary>
        public List<CartItem> CartLine { get; set; }
    }
}
