namespace GitHubClient.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using GitHubClient.DataServices;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Moq;
    using Xunit;

    /// <summary>
    /// Tests for Repository service.
    /// </summary>
    public class RepositoryServiceTest
    {
        /// <summary>
        /// Test CreateRepository when passed null as param.
        /// </summary>
        [Fact]
        public void TestNullDataInRepositoryCreation()
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Created);
            var mock = new Mock<IRequestSender>();
            var url = UrlConstants.CurrentUserRepositoriesUrl;
            mock.Setup(sender => sender.SendGetRequestToGitHubApiAsync(url))
                .ReturnsAsync(httpResponse);
            RepositoryService repoService = new RepositoryService(mock.Object);
            ClientResponse<string> testResponse = repoService.CreateRepository(null).GetAwaiter().GetResult();
            Assert.Equal(MessageConstants.EmptyData, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Test CreateRepository if Name of repository is empty.
        /// </summary>
        [Fact]
        public void TestEmptyNameInCreation()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestToGitHubApiAsync(UrlConstants.CurrentUserRepositoriesUrl))
                .ReturnsAsync(httpResponseMessage);
            RepositoryService repoService = new RepositoryService(mock.Object);
            CreateRepositoryModel createModel = new CreateRepositoryModel(string.Empty, string.Empty);
            ClientResponse<string> testResponse = repoService.CreateRepository(createModel).GetAwaiter().GetResult();
            Assert.Equal(MessageConstants.EmptyData, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetUserRepositories with empty string parameter.
        /// </summary>
        [Fact]
        public void TestGetUserRepositoriesEmptyUsername()
        {
            var mock = new Mock<IRequestSender>();
            RepositoryService repoService = new RepositoryService(mock.Object);
            ClientResponse<IEnumerable<FullRepositoryData>> testResponse =
                repoService.GetUserRepositories(string.Empty).GetAwaiter().GetResult();
            Assert.Equal(MessageConstants.EmptyData, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Tests GetUserRepositories with null user.
        /// </summary>
        [Fact]
        public void TestGetUserRepositoriesNullUser()
        {
            var mock = new Mock<IRequestSender>();
            RepositoryService repoService = new RepositoryService(mock.Object);
            ClientResponse<IEnumerable<FullRepositoryData>> testResponse =
                repoService.GetUserRepositories((BasicUserData)null).GetAwaiter().GetResult();
            Assert.Equal(MessageConstants.EmptyData, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }
    }
}
