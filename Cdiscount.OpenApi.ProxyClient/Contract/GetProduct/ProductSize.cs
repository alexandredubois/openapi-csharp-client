namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    public class ProductSize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}