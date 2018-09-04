namespace GitHubClient.Interfaces
{
    /// <summary>
    /// Interface of factory to create services.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Creates service to work with users.
        /// </summary>
        /// <returns>Instance that implements IUserService.</returns>
        IUserService CreateUserService();

        /// <summary>
        /// Creates service to work with repositories.
        /// </summary>
        /// <returns>Instance that implements IRepositoryService.</returns>
        IRepositoryService CreateRepositoryService();

        /// <summary>
        /// Creates service to work with branches.
        /// </summary>
        /// <returns>Instance that implements IBranchService.</returns>
        IBranchService CreateBranchService();

        /// <summary>
        /// Creates service to work with commits.
        /// </summary>
        /// <returns>Instance that implements ICommitService.</returns>
        ICommitService CreateCommitServcie();
    }
}
