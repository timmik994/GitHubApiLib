namespace GitHubClient
{
    /// <summary>
    /// Statuses of operations with gitHub api.
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// Pperation ends sussessful.
        /// </summary>
        Susseess,

        /// <summary>
        /// Has error during operation.
        /// </summary>
        Error,

        /// <summary>
        /// Requested data not found.
        /// </summary>
        NotFound,

        /// <summary>
        /// Has unknown error during operation.
        /// </summary>
        UnknownState,

        /// <summary>
        ///  Data passed as parameter is empty.
        /// </summary>
        EmptyData
    }

    /// <summary>
    /// Response object from libraly.
    /// </summary>
    /// <typeparam name="T">Type of data in response</typeparam>
    public class ClientResponse<T>
    {
        /// <summary>
        /// Gets or sets status of operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message of operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data returned by operation.
        /// </summary>
        public T ResponseData { get; set; }
    }

}
