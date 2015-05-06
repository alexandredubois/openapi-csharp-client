namespace Cdiscount.OpenApi.ProxyClient.Contract.Common
{
    /// <summary>
    /// Base response message for open api results
    /// </summary>
    public class BaseResponseMessage
    {
        /// <summary>
        /// True if the operation ended successfully
        /// </summary>
        public bool OperationSuccess { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
