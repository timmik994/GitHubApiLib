namespace GitHubClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with repositories.
    /// </summary>
    public interface IRepositoryService
    {
        /// <summary>
        /// Gets repositories of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>with with collection of repositories of specified user.</returns>
        Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(string username);

        /// <summary>
        /// Gets repositories of specified user.
        /// </summary>
        /// <param name="userData">The basic data of the user.</param>
        /// <returns>ClientResponse instance with cllection of repositories of specified user.</returns>
        Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(BasicUserData userData);

        /// <summary>
        /// Gets full data of repository.
        /// </summary>
        /// <param name="repositoryData">Basic repository data.</param>
        /// <returns>ClientResponse instance with full data of repository.</returns>
        Task<ClientResponse<FullRepositoryData>> GetFullRepositoryData(BasicRepositoryData repositoryData);

        /// <summary>
        /// Gets list of repositories of current user.
        /// </summary>
        /// <returns>ClientResponse with collection of repositories.</returns>
        Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetCurrentUserRepository();

        /// <summary>
        /// Creates repository on gitHub.
        /// </summary>
        /// <param name="repositoryData">Data of new repository.</param>
        /// <returns>Client response with operation status.</returns>
        Task<ClientResponse<string>> CreateRepository(CreateRepositoryModel repositoryData);
    }
}
