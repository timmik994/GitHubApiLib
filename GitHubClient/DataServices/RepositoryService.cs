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
    public class RepositoryService : AbstractGitHubService, IRepositoryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public RepositoryService(IRequestSender requestSender) : base(requestSender)
        {
        }

        /// <summary>
        /// Creates repository in gitHub.
        /// </summary>
        /// <param name="repositoryData">Data of new repository.</param>
        /// <returns>Client response with status of operation.</returns>
        public async Task<ClientResponse<string>> CreateRepository(CreateRepositoryModel repositoryData)
        {
            ClientResponse<string> clientResponse;
            if (repositoryData == null || repositoryData.Name == string.Empty)
            {
                clientResponse = new ClientResponse<string>
                {
                    ResponseData = string.Empty,
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                string repositoryJson = JsonConvert.SerializeObject(repositoryData);
                HttpResponseMessage httpResponse =
                    await this.RequestSender.SendPostRequestToGitHubApiAsync(
                        UrlConstants.CurrentUserRepositoriesUrl,
                        repositoryJson);
                clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<string>(
                    httpResponse,
                    MessageConstants.ObjectNotFound);
            }

            return clientResponse;
        }

        /// <summary>
        /// Gets list of repositories of current user.
        /// </summary>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetCurrentUserRepository()
        {
            HttpResponseMessage httpResponse = 
                await this.RequestSender.SendGetRequestToGitHubApiAsync(UrlConstants.CurrentUserRepositoriesUrl);
            ClientResponse<IEnumerable<FullRepositoryData>> clientResponse = 
                await HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                httpResponse,
                MessageConstants.ObjectNotFound);
            return clientResponse;
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
            HttpResponseMessage httpResponse = await this.RequestSender.SendGetRequestToGitHubApiAsync(url);
            var clientResponse = new ClientResponse<FullRepositoryData>();
            string notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessageConstants.UserOrRepositoryNotFoundTemplate, 
                repositoryData.Owner.Login, 
                repositoryData.Name);
            clientResponse = 
                await HttpResponceParseHelper.ProcessHttpResponse<FullRepositoryData>(
                httpResponse,
                notFoundMessage);
            return clientResponse;
        }

        /// <summary>
        /// Gets list of repositories of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(string username)
        {
            ClientResponse<IEnumerable<FullRepositoryData>> clientResponse;
            if (string.IsNullOrEmpty(username))
            {
                clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                var url = string.Format(
                    CultureInfo.InvariantCulture, 
                    UrlConstants.UserRepositoriesUrlTemplate, 
                    username);
                HttpResponseMessage httpResponse = await this.RequestSender.SendGetRequestToGitHubApiAsync(url);
                var notFoundMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    MessageConstants.UserNotFoundTemplate,
                    username);
                clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                    httpResponse,
                    notFoundMessage);
            }

            return clientResponse;
        }

        /// <summary>
        /// Gets list of repositories of specified user.
        /// </summary>
        /// <param name="userData">The basic user data object.</param>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetUserRepositories(BasicUserData userData)
        {
            ClientResponse<IEnumerable<FullRepositoryData>> clientResponse;
            if (userData == null)
            {
                clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                clientResponse = await this.GetUserRepositories(userData.Login);
            }

            return clientResponse;
        }
    }
}
