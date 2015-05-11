namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchRequestWrapper
    {
        /// <summary>
        /// Private cdiscount open api key
        /// </summary>
        public string ApiKey { get; set; }

        public SearchRequest SearchRequest { get; set; }
    }
}