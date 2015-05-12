namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public class SearchRequestPagination
    {
        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public SearchRequestPagination()
        {
            ItemsPerPage = 10;
        }
    }
}