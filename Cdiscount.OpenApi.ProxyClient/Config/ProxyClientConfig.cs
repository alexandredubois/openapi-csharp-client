using System;

namespace Cdiscount.OpenApi.ProxyClient.Config
{
    /// <summary>
    /// Configuration settings to reach the Cdiscount OpenApi
    /// </summary>
    public class ProxyClientConfig
    {
        #region Fields

        private static readonly TimeSpan s_defaultTimeout = TimeSpan.FromSeconds(100);
        private static readonly TimeSpan s_maxTimeout = TimeSpan.FromMilliseconds(int.MaxValue);
        private static readonly TimeSpan s_infiniteTimeout = System.Threading.Timeout.InfiniteTimeSpan;

        private TimeSpan _timeout = s_defaultTimeout;

        #endregion Fields

        /// <summary>
        /// Private Api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Enable debug mode
        /// </summary>
        public bool DebugModeEnabled { get; set; }

        /// <summary>
        /// Default Timeout
        /// </summary>
        /// <remarks> 
        /// Default value is 100 seconds.
        /// </remarks>
        public TimeSpan Timeout
        {
            get { return _timeout; }
            set
            {
                if (value != s_infiniteTimeout && (value <= TimeSpan.Zero || value > s_maxTimeout))
                {
                    throw new ArgumentOutOfRangeException(nameof(Timeout));
                }

                _timeout = value;
            }
        }
    }
}
