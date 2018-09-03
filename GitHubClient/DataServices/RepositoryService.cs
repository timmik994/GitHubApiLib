namespace GitHubClient.DataServices
{
    using System.Collections.Generic;
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
        /// Instance of requsetSender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService" /> class.
        /// </summary>
        /// <param name="requestSender">The IRequestSender instance.</param>
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
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            string repositoryJson = JsonConvert.SerializeObject(repositoryData);
            var url = $"/{UrlConstants.UsersUrlPart}/{UrlConstants.RepositoriesUrlPart}";
            HttpResponseMessage httpResponse = 
                await this.requestSender.SendPostRequestToGitHubApiAsync(url, repositoryJson);
            return await this.requestSender.ProcessHttpResponse<string>(
                httpResponse, 
                MessagesHelper.StandartNotFoundMessage);
        }

        /// <summary>
        /// Gets list of repositories of current user.
        /// </summary>
        /// <returns>ClientResponse with collection of repositories.</returns>
        public async Task<ClientResponse<IEnumerable<FullRepositoryData>>> GetCurrentUserRepository()
        {
            var url = $"/{UrlConstants.CurrentUserUrlPart}/{UrlConstants.RepositoriesUrlPart}";
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var clientResponse = new ClientResponse<IEnumerable<FullRepositoryData>>();
            return await this.requestSender.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                httpResponse, 
                MessagesHelper.StandartNotFoundMessage);
        }

        /// <summary>
        /// Get full repository data based on basic repository data.
        /// </summary>
        /// <param name="repositoryData">Basic repository data.</param>
        /// <returns>Full repository data of specified repository.</returns>
        public async Task<ClientResponse<FullRepositoryData>> GetFullRepositoryData(BasicRepositoryData repositoryData)
        {
            var url = $"/{UrlConstants.RepositoriesUrlPart}/{repositoryData.Owner.Login}/{repositoryData.Name}";
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var clientResponse = new ClientResponse<FullRepositoryData>();
            string notFoundMessage =
                MessagesHelper.GenerateUserOrRepositoryNotFoundMessage(
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
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = $"/{UrlConstants.UsersUrlPart}/{username}/{UrlConstants.RepositoriesUrlPart}";
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<FullRepositoryData>>(
                httpResponse, 
                MessagesHelper.GenerateUserNotFoundMessage(username));
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
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetUserRepositories(userData.Login);
        }
    }
}
