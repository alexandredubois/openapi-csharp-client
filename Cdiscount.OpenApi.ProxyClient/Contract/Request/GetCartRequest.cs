using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Request
{
    /// <summary>
    /// GetCart request object
    /// </summary>
    public class GetCartRequest
    {
        public Guid CartGuid { get; set; }
    }
}
