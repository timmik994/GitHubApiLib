namespace GitHubClient.Tests
{
    using System.Collections.Generic;
    using GitHubClient.DataServices;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Moq;
    using Xunit;

    /// <summary>
    /// Tests for BranchService.
    /// </summary>
    public class BranchesServiceTest
    {
        /// <summary>
        /// Tests GetBranchList if repository name is empty.
        /// </summary>
        [Fact]
        public void TestGetBranchesIfUsernameEmpty()
        {
            var mock = new Mock<IRequestSender>();
            BranchService branchService = new BranchService(mock.Object);
            ClientResponse<IEnumerable<Branch>> testResponse =
                branchService.GetBranchList(string.Empty, "repoName").GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetBranchList if username is empty.
        /// </summary>
        [Fact]
        public void TestGetBranchesIfrepoNameEmpty()
        {
            var mock = new Mock<IRequestSender>();
            BranchService branchService = new BranchService(mock.Object);
            ClientResponse<IEnumerable<Branch>> testResponse =
                branchService.GetBranchList("username", string.Empty).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetBranchList if repository object is null.
        /// </summary>
        [Fact]
        public void TestGetBranchesNullParam()
        {
            var mock = new Mock<IRequestSender>();
            BranchService branchService = new BranchService(mock.Object);
            ClientResponse<IEnumerable<Branch>> testResponse =
                branchService.GetBranchList((BasicRepositoryData)null).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }
    }
}
