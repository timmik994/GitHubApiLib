namespace GitHubClient.DataServices
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Newtonsoft.Json;

    /// <summary>
    /// Service that works with repositories.
    /// </summary>
    public class RepositoryService : IRepositoryService
    {
        /// <summary>
        /// The request sender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public RepositoryService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Creates repository in gitHub.
        /// </summary>
        /// <param name="repositoryData">Data of new repository.</param>
        /// <returns>Client response with status of operation.</returns>
        public async Task<ClientResponse<string>> CreateRepository(CreateRepositoryModel repositoryData)
        {
            if (repositoryData == null || repositoryData.Name == string.Empty)
            {
                var clientResponse = new ClientResponse<string>
                {
                    ResponseData = string.Empty,
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            string repositoryJson = JsonConvert.SerializeObject(repositoryData);
            HttpResponseMessage httpResponse = 
                await this.requestSender.SendPostRequestToGitHubApiAsync(
                    UrlConstants.CurrentUserRepositoriesUrl, 
                    repositoryJson);
            return await this.requestSender.ProcessHttpResponse<string>(
                httpResponse, 
                MessageConstants.ObjectNotFound);
        }

        /// <summary>
        /// Gets list of repositories of current user.
        /// </summary>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetCurrentUserRepository()
        {
            HttpResponseMessage httpResponse = 
                await this.requestSender.SendGetRequestToGitHubApiAsync(UrlConstants.CurrentUserRepositoriesUrl);
            var clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>();
            return await this.requestSender.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                httpResponse, 
                MessageConstants.ObjectNotFound);
        }

        /// <summary>
        /// Get full repository data based on basic repository data.
        /// </summary>
        /// <param name="repositoryData">Basic repository data.</param>
        /// <returns>Full repository data of specified repository.</returns>
        public async Task<ClientResponse<FullRepositoryData>> GetFullRepositoryData(BasicRepositoryData repositoryData)
        {
            var url = string.Format(
                CultureInfo.InvariantCulture, 
                UrlConstants.RepositoryDataUrlTemplate,
                repositoryData.Owner.Login, 
                repositoryData.Name);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var clientResponse = new ClientResponse<FullRepositoryData>();
            string notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessageConstants.UserOrRepositoryNotFoundTemplate, 
                repositoryData.Owner.Login, 
                repositoryData.Name);
            return await this.requestSender.ProcessHttpResponse<FullRepositoryData>(
                httpResponse, 
                notFoundMessage);
        }

        /// <summary>
        /// Gets list of repositories of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(string username)
        {
            if (username == string.Empty)
            {
                var clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = string.Format(CultureInfo.InvariantCulture, UrlConstants.UserRepositoriesUrlTemplate, username);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessageConstants.UserNotFoundTemplate,
                username);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                httpResponse, 
                notFoundMessage);
        }

        /// <summary>
        /// Gets list of repositories of specified user.
        /// </summary>
        /// <param name="userData">The basic user data object.</param>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(BasicUserData userData)
        {
            if (userData == null)
            {
                var clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetUserRepositories(userData.Login);
        }
    }
}
