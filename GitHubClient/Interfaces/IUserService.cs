namespace GitHubClient.Interfaces
{
    using System.Threading.Tasks;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets data about current user.
        /// </summary>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        Task<ClientResponse<FullUserData>> GetCurrentUser();

        /// <summary>
        /// Get full data about user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponse instance with full data about specified user.</returns>
        Task<ClientResponse<FullUserData>> GetFullUserData(string username);

        /// <summary>
        /// Get full user data about specified user.
        /// </summary>
        /// <param name="userData">The basic user data.</param>
        /// <returns>ClientResponse instance with full data about specified user.</returns>
        Task<ClientResponse<FullUserData>> GetFullUserData(BasicUserData userData);
    }
}
