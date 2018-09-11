namespace GitHubClient
{
    using GitHubClient.DataServices;
    using GitHubClient.Interfaces;

    /// <summary>
    ///  Implementation of factory to create services.
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        /// <summary>
        /// Access token of gitHub.
        /// </summary>
        private string accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// </summary>
        /// <param name="accessToken">Access token of gitHub.</param>
        public ServiceFactory(string accessToken)
        {
            this.accessToken = accessToken;
        }

        /// <summary>
        /// Creates Service to work with branches.
        /// </summary>
        /// <returns>Instance that implements IBranchService.</returns>
        public IBranchService CreateBranchService()
        {
            var sender = new HttpRequestSender(this.accessToken);
            var branchService = new BranchService(sender);
            return branchService;
        }

        /// <summary>
        /// Creates Service to work with commits.
        /// </summary>
        /// <returns>Instance that implements ICommitService.</returns>
        public ICommitService CreateCommitServcie()
        {
            var sender = new HttpRequestSender(this.accessToken);
            var commitService = new CommitService(sender);
            return commitService;
        }

        /// <summary>
        /// Creates Service to work with repositories.
        /// </summary>
        /// <returns>Instance that implements IRepositoryService.</returns>
        public IRepositoryService CreateRepositoryService()
        {
            var sender = new HttpRequestSender(this.accessToken);
            var repositoryService = new RepositoryService(sender);
            return repositoryService;
        }

        /// <summary>
        /// Creates Service to work with users.
        /// </summary>
        /// <returns>Instance that implements IUserService.</returns>
        public IUserService CreateUserService()
        {
            var sender = new HttpRequestSender(this.accessToken);
            var userService = new UserService(sender);
            return userService;
        }
    }
}
