namespace GitHubClient.DataServices
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with branch data.
    /// </summary>
    public class BranchService : IBranchService
    {
        /// <summary>
        /// Instance of requsetSender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchService" /> class.
        /// </summary>
        /// <param name="requestSender">Instance of requsetSender.</param>
        public BranchService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="username">The name of repository owner.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(string username, string repositoryName)
        {
            if (username == string.Empty || repositoryName == string.Empty)
            {
                var clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessagesConstants.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = string.Format(
                CultureInfo.InvariantCulture, 
                UrlConstants.RepositoryBranchesUrlTemplate, 
                username,
                repositoryName);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            string notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessagesConstants.UserOrRepositoryNotFoundMessageTemplate,
                username,
                repositoryName);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<Branch>>(
                httpResponse, 
                notFoundMessage);
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="repositoryData">The basic data of repository.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(BasicRepositoryData repositoryData)
        {
            if (repositoryData == null)
            {
                var clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessagesConstants.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetBranchList(repositoryData.Owner.Login, repositoryData.Name);
        }
    }
}
