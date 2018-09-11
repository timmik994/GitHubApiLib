namespace GitHubClient
{
    /// <summary>
    /// Message helper class.
    /// </summary>
    public static class MessageConstants
    {
        /// <summary>
        /// Success operation message.
        /// </summary>
        public const string SuccessOperation = "Operation end with success.";

        /// <summary>
        /// Data already loaded message.
        /// </summary>
        public const string DataAlreadyLoaded = "Data already loaded from gitHub.";

        /// <summary>
        /// Unauthorized status code message.
        /// </summary>
        public const string Unauthorized = "Invalid access token.";

        /// <summary>
        /// Unknown error message.
        /// </summary>
        public const string UnknownError = "Operation ended with unknown error.";

        /// <summary>
        /// Object is null or empty message.
        /// </summary>
        public const string EmptyData = "Passed data is null or empty.";

        /// <summary>
        /// Json string has incorrect json format message.
        /// </summary>
        public const string InvalidJson = "Json object from server has invalid format.";

        /// <summary>
        /// Requested object not found message.
        /// </summary>
        public const string ObjectNotFound = "Requested data not found.";

        /// <summary>
        /// Template for user not found message.
        /// </summary>
        public const string UserNotFoundTemplate = "User {0} Not found.";

        /// <summary>
        /// Template for user or repository not found message.
        /// </summary>
        public const string UserOrRepositoryNotFoundTemplate = "User {0} or repository {1} not found.";

        /// <summary>
        /// Template for user, repository or branch not found message.
        /// </summary>
        public const string RepoUserBranchNotFoundTemplate = "User {0} or repository {1} or branch {2} not found.";

        /// <summary>
        /// Template for invalid json string message.
        /// </summary>
        public const string InvalidJsonErrorTemplate = "{0}: {1}";
    }
}
