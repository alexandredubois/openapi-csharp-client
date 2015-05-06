namespace Cdiscount.OpenApi.ProxyClient.Contract.GetCart
{
    /// <summary>
    /// Wrapper object to serialize for calling GetCart action
    /// </summary>
    public class GetCartRequestWrapper
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
