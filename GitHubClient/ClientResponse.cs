namespace GitHubClient
{
    /// <summary>
    /// Response object from library.
    /// </summary>
    /// <typeparam name="T">Type of data in response.</typeparam>
    public class ClientResponse<T>
    {
        /// <summary>
        /// Gets or sets status of operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets message from operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data returned by operation.
        /// </summary>
        public T ResponseData { get; set; }
    }

}
