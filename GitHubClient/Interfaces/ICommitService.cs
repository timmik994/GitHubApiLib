namespace GitHubClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with commit data.
    /// </summary>
    public interface ICommitService
    {
        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="repository">The repository data.</param>
        /// <param name="branch">The branch data.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        Task<ClientResponse<IEnumerable<Commit>>> GetBranchCommits(BasicRepositoryData repository, Branch branch);

        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="username">The repository owner name.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <param name="branchName">The branch name.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        Task<ClientResponse<IEnumerable<Commit>>> GetBranchCommits(
            string username, 
            string repositoryName, 
            string branchName);

        /// <summary>
        /// Get commits from specified repository.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repositoryName">The name of the repository.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        Task<ClientResponse<IEnumerable<Commit>>> GetRepositoryCommits(string username, string repositoryName);

        /// <summary>
        /// Get commits from specified repository.
        /// </summary>
        /// <param name="repository">The basic data of the repository.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        Task<ClientResponse<IEnumerable<Commit>>> GetRepositoryCommits(BasicRepositoryData repository);

        /// <summary>
        /// Get Full commit data based on basic commit data.
        /// </summary>
        /// <param name="basicCommitData">The basic data of the commit.</param>
        /// <returns>ClientResponse instance with full data of the commit.</returns>
        Task<ClientResponse<Commit>> GetCommitData(BasicCommitData basicCommitData);
    }
}
