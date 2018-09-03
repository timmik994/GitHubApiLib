namespace GitHubClient.Tests
{
    using System.Collections.Generic;
    using GitHubClient.DataServices;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Moq;
    using Xunit;

    /// <summary>
    /// Tests for CommitService.
    /// </summary>
    public class CommitServiceTest
    {
        /// <summary>
        /// Tests GetBranchCommits if one of parameters is empty.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repositoryName">The repository name.</param>
        /// <param name="branchName">The branch name.</param>
        [Theory]
        [InlineData("", "repository", "branch")]
        [InlineData("username", "", "branch")]
        [InlineData("username", "repository", "")]
        public void TestGetBranchCommitsIfHasEmptyParam(string username, string repositoryName, string branchName)
        {
            var mock = new Mock<IRequestSender>();
            var commitService = new CommitService(mock.Object);
            ClientResponse<IEnumerable<Commit>> testResponse =
                commitService.GetBranchCommits(username, repositoryName, branchName).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetBranchCommits if repository is null. 
        /// </summary>
        [Fact]
        public void TestGetBranchCommitsIfRepositoryNull()
        {
            var mock = new Mock<IRequestSender>();
            var commitService = new CommitService(mock.Object);
            ClientResponse<IEnumerable<Commit>> testResponse =
                commitService.GetBranchCommits(null, new Branch()).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetBranchCommits if branch is null. 
        /// </summary>
        [Fact]
        public void TestGetBranchCommitsIfBranchNull()
        {
            var mock = new Mock<IRequestSender>();
            var commitService = new CommitService(mock.Object);
            ClientResponse<IEnumerable<Commit>> testResponse =
                commitService.GetBranchCommits(new BasicRepositoryData(), null).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetRepositoryCommits if has empty param.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="repositoryName">The name of repository.</param>
        [Theory]
        [InlineData("", "repository")]
        [InlineData("username", "")]
        public void TestGetRepositoryCommitsIfHasEmptyParam(string username, string repositoryName)
        {
            var mock = new Mock<IRequestSender>();
            var commitService = new CommitService(mock.Object);
            ClientResponse<IEnumerable<Commit>> testResponse =
                commitService.GetRepositoryCommits(username, repositoryName).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetRepositoryCommits if repository is null. 
        /// </summary>
        [Fact]
        public void TestGetRepositoryCommitsIfRepositoryNull()
        {
            var mock = new Mock<IRequestSender>();
            var commitService = new CommitService(mock.Object);
            ClientResponse<IEnumerable<Commit>> testResponse =
                commitService.GetRepositoryCommits((BasicRepositoryData)null).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }
    }
}
