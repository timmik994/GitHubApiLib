namespace GitHubClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with branches.
    /// </summary>
    public interface IBranchService
    {
        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="username">The name of repository owner.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(string username, string repositoryName);

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="repositoryData">The data of repository.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(BasicRepositoryData repositoryData);
    }
}
