namespace Cdiscount.OpenApi.ProxyClient.Contract.Exception
{
    /// <summary>
    /// Exception raised when a call is done without passing an API key
    /// </summary>
    public class MissingApiKeyException : System.Exception
    {
        /// <summary>
        /// Raise an exception providing a specific message and an inner exception
        /// </summary>
        /// <param name="message">specific message</param>
        /// <param name="inner">inner exception</param>
        public MissingApiKeyException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Raise an exception providing a specific message
        /// </summary>
        /// <param name="message">specific message</param>
        public MissingApiKeyException(string message)
            : base(message)
        {
        }
    }
}
