namespace GitHubClient
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with users.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Owner of access token 
        /// </summary>
        private FullUserData currentUser;

        /// <summary>
        /// Instance of requsetSender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="requestSender">The IRequestSender instance.</param>
        public UserService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Gets user who is owner of access token.
        /// </summary>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetCurrentUser()
        {
            if (this.currentUser != null)
            {
                var clientResponse = new ClientResponse<FullUserData>()
                {
                    Message = MessagesHelper.DataAlreadyLoadedMessage,
                    ResponseData = this.currentUser,
                    Status = OperationStatus.Susseess
                };
                return clientResponse;
            }
            else
            {
                var url = $"/{UrlConstants.CurrentUserUrlPart}";
                HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
                ClientResponse<FullUserData> clientResponse = 
                    await this.requestSender.ProcessHttpResponse<FullUserData>(
                        httpResponse, 
                        MessagesHelper.StandartNotFoundMessage);
                this.currentUser = clientResponse.ResponseData;
                return clientResponse;
            }
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetFullUserData(string username)
        {
            if (username == string.Empty)
            {
                var clientResponse = new ClientResponse<FullUserData>();
                clientResponse.Message = MessagesHelper.EmptyDataMessage;
                clientResponse.Status = OperationStatus.EmptyData;
                return clientResponse;
            }

            var url = $"/{UrlConstants.UsersUrlPart}/{username}";
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            return await this.requestSender.ProcessHttpResponse<FullUserData>(
                httpResponse, 
                MessagesHelper.GenerateUserNotFoundMessage(username));
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="userData">The BasicUserData object.</param>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetFullUserData(BasicUserData userData)
        {
            if (userData != null)
            {
                return await this.GetFullUserData(userData.Login);
            }
            else
            {
                var clientResponse = new ClientResponse<FullUserData>()
                {
                    Message = MessagesHelper.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }
        }
    }
}
