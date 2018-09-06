namespace GitHubClient.DataServices
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;

    /// <summary>
    /// Service that works with commit data.
    /// </summary>
    public class CommitService : AbstractGitHubService, ICommitService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommitService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public CommitService(IRequestSender requestSender) : base(requestSender)
        {
        }

        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="repository">The repository data.</param>
        /// <param name="branch">The branch data.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        public async Task<ClientResponse<IEnumerable<Commit>>> GetBranchCommits(
            BasicRepositoryData repository, 
            Branch branch)
        {
            ClientResponse<IEnumerable<Commit>> clientResponse;
            if (repository == null || branch == null)
            {
                clientResponse = new ClientResponse<IEnumerable<Commit>>()
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                clientResponse = await this.GetBranchCommits(
                    repository.Owner.Login, 
                    repository.Name, 
                    branch.Name);
            }

            return clientResponse;
        }

        /// <summary>
        /// Gets commits from specified branch in specified repository.
        /// </summary>
        /// <param name="username">The repository owner name.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <param name="branchName">The branch name.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        public async Task<ClientResponse<IEnumerable<Commit>>> GetBranchCommits(
            string username, 
            string repositoryName, 
            string branchName)
        {
            ClientResponse<IEnumerable<Commit>> clientResponse;
            if (string.IsNullOrEmpty(username)  || string.IsNullOrEmpty(repositoryName) || string.IsNullOrEmpty(branchName))
            {
                clientResponse = new ClientResponse<IEnumerable<Commit>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = string.Format(
                CultureInfo.InvariantCulture, 
                UrlConstants.BranchCommitsUrlTemplate, 
                username,
                repositoryName, 
                branchName);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            var notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessageConstants.RepoUserBranchNotFoundTemplate, 
                username, 
                repositoryName, 
                branchName);
            clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<Commit>>(
                httpResponse, 
                notFoundMessage);
            return clientResponse;
        }

        /// <summary>
        /// Get Full commit data based on basic commit data.
        /// </summary>
        /// <param name="basicCommitData">The basic data of the commit.</param>
        /// <returns>ClientResponse with full data of the commit.</returns>
        public async Task<ClientResponse<Commit>> GetCommitData(BasicCommitData basicCommitData)
        {
            ClientResponse<Commit> clientResponse;
            if (basicCommitData == null)
            {
                clientResponse = new ClientResponse<Commit>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                HttpResponseMessage httpResponse =
                    await this.requestSender.SendGetRequestToGitHubApiAsync(basicCommitData.Url);
                clientResponse = await HttpResponceParseHelper.ProcessHttpResponse<Commit>(
                    httpResponse,
                    MessageConstants.ObjectNotFound);
            }

            return clientResponse;
        }

        /// <summary>
        /// Get commits from specified repository.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repositoryName">The name of the repository.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        public async Task<ClientResponse<IEnumerable<Commit>>> GetRepositoryCommits(
            string username, 
            string repositoryName)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(repositoryName))
            {
                var clientResponse = new ClientResponse<IEnumerable<Commit>>
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            var url = string.Format(
                CultureInfo.InvariantCulture, 
                UrlConstants.RepositoryCommitsUrlTemplate, 
                username,
                repositoryName);
            HttpResponseMessage httpResponse = await this.requestSender.SendGetRequestToGitHubApiAsync(url);
            string notFoundMessage = string.Format(
                CultureInfo.InvariantCulture,
                MessageConstants.UserOrRepositoryNotFoundTemplate,
                username,
                repositoryName);
            return await HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<Commit>>(
                httpResponse, 
                notFoundMessage);
        }

        /// <summary>
        /// Get commits from specified repository.
        /// </summary>
        /// <param name="repository">The basic data of the repository.</param>
        /// <returns>ClientResponse instance with collections of commits.</returns>
        public async Task<ClientResponse<IEnumerable<Commit>>> GetRepositoryCommits(BasicRepositoryData repository)
        {
            ClientResponse<IEnumerable<Commit>> clientResponse;
            if (repository == null)
            {
                clientResponse = new ClientResponse<IEnumerable<Commit>>()
                {
                    Message = MessageConstants.EmptyData,
                    Status = OperationStatus.EmptyData
                };
            }
            else
            {
                clientResponse = await this.GetRepositoryCommits(
                    repository.Owner.Login, 
                    repository.Name);
            }

            return clientResponse;
        }
    }
}
