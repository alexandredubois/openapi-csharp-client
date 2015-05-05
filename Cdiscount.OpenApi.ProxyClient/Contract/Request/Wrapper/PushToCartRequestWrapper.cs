namespace Cdiscount.OpenApi.ProxyClient.Contract.Request
{
    /// <summary>
    /// Base request message
    /// </summary>
    public class PushToCartRequestWrapper
    {
        /// <summary>
        /// Private cdiscount open api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Action request message
        /// </summary>
        public PushToCartRequest PushToCartRequest { get; set; }
    }
}
