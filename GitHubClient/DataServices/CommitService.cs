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
    public class CommitService : ICommitService
    {
        /// <summary>
        /// Instance of requsetSender to send requests to gitHub API.
        /// </summary>
        private IRequestSender requestSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommitService" /> class.
        /// </summary>
        /// <param name="requestSender">Instance of requsetSender.</param>
        public CommitService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
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
            if (repository == null || branch == null)
            {
                var clientResponse = new ClientResponse<IEnumerable<Commit>>()
                {
                    Message = MessagesConstants.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetBranchCommits(repository.Owner.Login, repository.Name, branch.Name);
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
            if (username == string.Empty || repositoryName == string.Empty || branchName == string.Empty)
            {
                var clientResponse = new ClientResponse<IEnumerable<Commit>>
                {
                    Message = MessagesConstants.EmptyDataMessage,
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
                MessagesConstants.RepoUserBranchNotFoundMessageTemplate, 
                username, 
                repositoryName, 
                branchName);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<Commit>>(
                httpResponse, 
                notFoundMessage);
        }

        /// <summary>
        /// Get Full commit data based on basic commit data.
        /// </summary>
        /// <param name="basicCommitData">The basic data of the commit.</param>
        /// <returns>ClientResponse with full data of the commit.</returns>
        public async Task<ClientResponse<Commit>> GetCommitData(BasicCommitData basicCommitData)
        {
            if (basicCommitData == null)
            {
                var clientResponse = new ClientResponse<Commit>
                {
                    Message = MessagesConstants.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            HttpResponseMessage httpResponse = 
                await this.requestSender.SendGetRequestToGitHubApiAsync(basicCommitData.Url);
            return await this.requestSender.ProcessHttpResponse<Commit>(
                httpResponse, 
                MessagesConstants.StandartNotFoundMessage);
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
            if (username == string.Empty || repositoryName == string.Empty)
            {
                var clientResponse = new ClientResponse<IEnumerable<Commit>>
                {
                    Message = MessagesConstants.EmptyDataMessage,
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
                MessagesConstants.UserOrRepositoryNotFoundMessageTemplate,
                username,
                repositoryName);
            return await this.requestSender.ProcessHttpResponse<IEnumerable<Commit>>(
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
            if (repository == null)
            {
                var clientResponse = new ClientResponse<IEnumerable<Commit>>()
                {
                    Message = MessagesConstants.EmptyDataMessage,
                    Status = OperationStatus.EmptyData
                };
                return clientResponse;
            }

            return await this.GetRepositoryCommits(repository.Owner.Login, repository.Name);
        }
    }
}
