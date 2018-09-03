namespace GitHubClient.Interfaces
{
    /// <summary>
    /// Interface of factory to create services.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Creates Service to work with users.
        /// </summary>
        /// <returns>Instance that implements IUserService.</returns>
        IUserService CreateUserService();

        /// <summary>
        /// Creates Service to work with repositories.
        /// </summary>
        /// <returns>Instance that implements IRepositoryService.</returns>
        IRepositoryService CreateRepositoryService();

        /// <summary>
        /// Creates Service to work with branches.
        /// </summary>
        /// <returns>Instance that implements IBranchService.</returns>
        IBranchService CreateBranchService();

        /// <summary>
        /// Creates Service to work with commits.
        /// </summary>
        /// <returns>Instance that implements ICommitService.</returns>
        ICommitService CreateCommitServcie();
    }
}
