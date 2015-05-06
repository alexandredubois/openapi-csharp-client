using System.Collections.Generic;
using Cdiscount.OpenApi.ProxyClient.Contract.Common;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    /// <summary>
    /// Response message to GetProduct action
    /// </summary>
    public class GetProductResponse : BaseResponseMessage
    {
        /// <summary>
        /// Product found list
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
