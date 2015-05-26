using System;
using System.Configuration;

namespace Cdiscount.OpenApi.ProxyClient.Tests.Helper
{
    internal static class TestsHelper
    {
        /// <summary>
        /// Get the Cdiscount Open API key from the config or environment variable (useful for CI platforms)
        /// </summary>
        /// <returns>Cdiscount Open API key</returns>
        internal static string GetCdiscountOpenApiKey()
        {
            var key = ConfigurationManager.AppSettings["ApiKey"];
            if (string.IsNullOrWhiteSpace(key)) key = Environment.GetEnvironmentVariable("CDISCOUNT_OPEN_API_KEY");
            return key;
        }
    }
}
