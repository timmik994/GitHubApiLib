namespace GitHubClient
{
    /// <summary>
    /// Statuses of operations with gitHub API.
    /// </summary>
    public enum OperationStatus
    {
        /// <summary>
        /// Operation ended successful.
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
}