using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    public class ProductPriceDiscount
    {
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}