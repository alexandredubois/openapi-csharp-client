using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    public class BaseHttpContent : StringContent
    {
        public BaseHttpContent(string content)
            : base(content, Encoding.UTF8)
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}
