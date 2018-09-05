namespace GitHubClient
{
    using System.Globalization;
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
        /// Owner of access token.
        /// </summary>
        private FullUserData currentUser;

        /// <summary>
        /// The request sender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
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
                    Message = MessageConstants.DataAlreadyLoaded,
                    ResponseData = this.currentUser,
                    Status = OperationStatus.Susseess
                };
                return clientResponse;
            }
            else
            {
                HttpResponseMessage httpResponse = 
                    await this.requestSender.SendGetRequestToGitHubApiAsync(UrlConstants.CurrentUserUrl);
                ClientResponse<FullUserData> clientResponse = 
                    await this.requestSender.ProcessHttpResponse<FullUserData>(
                        httpResponse, 
                        MessageConstants.ObjectNotFound);
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
                clientResponse.Message = MessageConstants.EmptyData;
                clientResponse.Status = OperationStatus.EmptyData;
                return clientResponse;
            }

            var url = string.Format(CultureInfo.InvariantCulture, UrlConstants.UserDataUrlTemplate, username);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var notFoundMessage = string.Format(
                CultureInfo.InvariantCulture, 
                MessageConstants.UserNotFoundTemplate,
                username);
            return await this.requestSender.ProcessHttpResponse<FullUserData>(
                httpResponse, 
                notFoundMessage);
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
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }
        }
    }
}
