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
        public const string CurrentUserUrl = "/user";

        /// <summary>
        /// Template of URL to get data of user. {0} is username.
        /// </summary>
        public const string UserDataUrlTemplate = "/users/{0}";

        /// <summary>
        /// URL to get data about repositories of current user,
        /// or create new repository.
        /// </summary>
        public const string CurrentUserRepositoriesUrl = "/user/repos";

        /// <summary>
        /// Template of URL to get data about repository. {0} is username,
        /// {1} is repository name.
        /// </summary>
        public const string RepositoryDataUrlTemplate = "/repos/{0}/{1}";

        /// <summary>
        /// Template of URL to get data about repositories of user.
        /// {0} is username.
        /// </summary>
        public const string UserRepositoriesUrlTemplate = "/users/{0}/repos";

        /// <summary>
        /// Template of URL to get data about commits in repository.
        /// {0} is username, {1} is repository name.
        /// </summary>
        public const string RepositoryCommitsUrlTemplate = "/repos/{0}/{1}/commits";

        /// <summary>
        /// Template of URL to get data about commits in branch.
        /// {0} is username, {1} is repository name, {2} is branch name.
        /// </summary>
        public const string BranchCommitsUrlTemplate = "repos/{0}/{1}/commits?sha={2}";

        /// <summary>
        /// Template of URL to get branches of repository.
        /// {0} is username, {1} is repository name.
        /// </summary>
        public const string RepositoryBranchesUrlTemplate = "repos/{0}/{1}/branches";
    }
}
