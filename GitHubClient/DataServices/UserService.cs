namespace GitHubClient.DataServices
{
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with users.
    /// </summary>
    public class UserService : AbstractGitHubService, IUserService
    {
        /// <summary>
        /// Owner of access token.
        /// </summary>
        private FullUserData currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public UserService(IRequestSender requestSender) : base(requestSender)
        {
        }

        /// <summary>
        /// Gets user who is owner of access token.
        /// </summary>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetCurrentUser()
        {
            ClientResponse<FullUserData> clientResponse;
            if (this.currentUser != null)
            {
                clientResponse = new ClientResponse<FullUserData>()
                {
                    Message = MessageConstants.DataAlreadyLoaded,
                    ResponseData = this.currentUser,
                    Status = OperationStatus.Susseess
                };
            }
            else
            {
                HttpResponseMessage httpResponse = 
                    await this.RequestSender.SendGetRequestToGitHubApiAsync(UrlConstants.CurrentUserUrl);
                clientResponse = 
                    await HttpResponceParseHelper.ProcessHttpResponse<FullUserData>(
                        httpResponse, 
                        MessageConstants.ObjectNotFound);
                this.currentUser = clientResponse.ResponseData;
            }

            return clientResponse;
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetFullUserData(string username)
        {
            ClientResponse<FullUserData> clientResponse;
            if (string.IsNullOrEmpty(username))
            {
                clientResponse = new ClientResponse<FullUserData>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                var url = string.Format(CultureInfo.InvariantCulture, UrlConstants.UserDataUrlTemplate, username);
                HttpResponseMessage httpResponse = await this.RequestSender.SendGetRequestToGitHubApiAsync(url);
                var notFoundMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    MessageConstants.UserNotFoundTemplate,
                    username);
                clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<FullUserData>(
                    httpResponse,
                    notFoundMessage);
            }

            return clientResponse;
        }

        /// <summary>
        /// Gets full data of specified user.
        /// </summary>
        /// <param name="userData">The BasicUserData object.</param>
        /// <returns>ClientResponse instance with full data of current user.</returns>
        public async Task<ClientResponse<FullUserData>> GetFullUserData(BasicUserData userData)
        {
            ClientResponse<FullUserData> clientResponse;
            if (userData != null)
            {
                clientResponse = await this.GetFullUserData(userData.Login);
            }
            else
            {
                clientResponse = new ClientResponse<FullUserData>()
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }

            return clientResponse;
        }
    }
}
