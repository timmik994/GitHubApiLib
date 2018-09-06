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
    public class BranchService : AbstractGitHubService, IBranchService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BranchService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public BranchService(IRequestSender requestSender) : base(requestSender)
        {
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="username">The name of repository owner.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(string username, string repositoryName)
        {
            ClientResponse<IEnumerable<Branch>> clientResponse;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(repositoryName))
            {
                clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessageConstants.EmptyData,
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
                MessageConstants.UserOrRepositoryNotFoundTemplate,
                username,
                repositoryName);
            clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<Branch>>(
                httpResponse,
                notFoundMessage);
            return clientResponse;
        }

        /// <summary>
        /// Gets branches list of specified repository.
        /// </summary>
        /// <param name="repositoryData">The basic data of repository.</param>
        /// <returns>ClientResponse instance with collection of branches.</returns>
        public async Task<ClientResponse<IEnumerable<Branch>>> GetBranchList(BasicRepositoryData repositoryData)
        {
            ClientResponse<IEnumerable<Branch>> clientResponse;
            if (repositoryData == null)
            {
                clientResponse = new ClientResponse<IEnumerable<Branch>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                clientResponse = await this.GetBranchList(
                    repositoryData.Owner.Login, 
                    repositoryData.Name);
            }

            return clientResponse;
        }
    }
}
