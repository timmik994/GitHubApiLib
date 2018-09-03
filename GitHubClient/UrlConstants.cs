namespace GitHubClient
{
    /// <summary>
    /// Parts of URLs to gitHub API.
    /// </summary>
    public static class UrlConstants
    {
        /// <summary>
        /// Path to current user.
        /// </summary>
        public const string CurrentUserUrlPart = "user";

        /// <summary>
        /// Part of path to users.
        /// </summary>
        public const string UsersUrlPart = "users";

        /// <summary>
        /// Part of path to repositories.
        /// </summary>
        public const string RepositoriesUrlPart = "repos";

        /// <summary>
        /// Part of path to branches.
        /// </summary>
        public const string BranchesUrlPart = "branches";

        /// <summary>
        /// Part of path to commits.
        /// </summary>
        public const string CommitsUrlPart = "commits";
    }
}
