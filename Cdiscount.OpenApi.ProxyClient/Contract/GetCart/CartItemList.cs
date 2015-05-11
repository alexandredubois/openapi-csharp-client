using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Helper;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(SingleValueArrayConverter<CartItem>))]
        public List<CartItem> CartLine { get; set; }
    }
}
