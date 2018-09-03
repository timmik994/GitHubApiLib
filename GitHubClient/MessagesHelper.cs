namespace GitHubClient
{
    /// <summary>
    /// Message helper class.
    /// </summary>
    public static class MessagesHelper
    {
        /// <summary>
        /// Message if operation successful
        /// </summary>
        public const string StandartSuccessMessage = "Operation end with success.";

        /// <summary>
        /// Message is data loaded from local source.
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
        /// Message if user not found.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The client message.</returns>
        public static string GenerateUserNotFoundMessage(string username)
        {
            return $"User {username} Not found.";
        }

        /// <summary>
        /// Generates message if user or repository not found.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repoName">The name of repository.</param>
        /// <returns>The client message.</returns>
        public static string GenerateUserOrRepositoryNotFoundMessage(string username, string repoName)
        {
            return $"User {username} or repository {repoName} not found.";
        }

        /// <summary>
        /// Generates message if user, repository or branch not found.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repoName">The name of repository.</param>
        /// <param name="branchName">The name of the branch.</param>
        /// <returns>The client message.</returns>
        public static string GenerateRepoUserBranchNotFoundMessage(string username, string repoName, string branchName)
        {
            return $"User {username} or repository {repoName} or branch {branchName} not found.";
        }
    }
}
