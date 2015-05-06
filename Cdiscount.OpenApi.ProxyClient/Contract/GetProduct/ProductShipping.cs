using System;

namespace Cdiscount.OpenApi.ProxyClient.Contract.GetProduct
{
    public class ProductShipping
    {
        public string Name { get; set; }
        public string DelayToDisplay { get; set; }
        public decimal Price { get; set; }
        public DateTime MaxDeliveryDate { get; set; }
        public DateTime MinDeliveryDate { get; set; }
    }
}
