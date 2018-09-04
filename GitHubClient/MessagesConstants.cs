namespace GitHubClient
{
    /// <summary>
    /// Message helper class.
    /// </summary>
    public static class MessagesConstants
    {
        /// <summary>
        /// Message if operation successful.
        /// </summary>
        public const string StandartSuccessMessage = "Operation end with success.";

        /// <summary>
        /// Message if data loaded from local source.
        /// </summary>
        public const string DataAlreadyLoadedMessage = "Data already loaded from gitHub.";

        /// <summary>
        /// Message if unauthorized status code.
        /// </summary>
        public const string UnauthorizedMessage = "Invalid access token.";

        /// <summary>
        /// Message if unknown error.
        /// </summary>
        public const string UnknownErrorMessage = "Operation ended with unknown error.";

        /// <summary>
        /// Message if object is null or has empty field.
        /// </summary>
        public const string EmptyDataMessage = "Passed data is null or empty.";

        /// <summary>
        /// Message if json string has incorrect json format.
        /// </summary>
        public const string InvalidJsonMessage = "Json object from server has invalid format.";

        /// <summary>
        /// Standard message for NotFound status.
        /// </summary>
        public const string StandartNotFoundMessage = "Requested data not found.";

        /// <summary>
        /// Template for message if user not found.
        /// </summary>
        public const string UserNotFoundMessageTemplate = "User {0} Not found.";

        /// <summary>
        /// Template for message if user or repository not found.
        /// </summary>
        public const string UserOrRepositoryNotFoundMessageTemplate = "User {0} or repository {1} not found.";

        /// <summary>
        /// Template for message if user, repository or branch not found.
        /// </summary>
        public const string RepoUserBranchNotFoundMessageTemplate = "User {0} or repository {1} or branch {2} not found.";
    }
}
