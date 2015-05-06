namespace Cdiscount.OpenApi.ProxyClient.Contract.Request.Wrapper
{
    /// <summary>
    /// Wrapper object to serialize for calling GetProduct action
    /// </summary>
    public class GetProductRequestWrapper
    {
        /// <summary>
        /// Private cdiscount open api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Product request informations
        /// </summary>
        public GetProductRequest ProductRequest { get; set; }
    }
}
