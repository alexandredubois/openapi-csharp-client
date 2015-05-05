namespace Cdiscount.OpenApi.ProxyClient.Contract.Request.Wrapper
{
    /// <summary>
    /// Wrapper object to serialize and call GetCart action
    /// </summary>
    public class GetCartWrapper
    {
        /// <summary>
        /// Private cdiscount open api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Cart request information
        /// </summary>
        public GetCartRequest CartRequest { get; set; }
    }
}
