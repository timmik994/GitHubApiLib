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
            var httpresponse = new HttpResponseMessage(HttpStatusCode.Created);
            var mock = new Mock<IRequestSender>();
            var url = $"/{UrlConstants.UsersUrlPart}/{UrlConstants.RepositoriesUrlPart}";
            var mockResponse = new ClientResponse<string>()
            {
                Message = MessagesHelper.StandartSuccessMessage,
                Status = OperationStatus.Susseess
            };

            mock.Setup(sender => sender.SendGetRequestToGitHubApiAsync(url))
                .ReturnsAsync(httpresponse);
            mock.Setup(sender =>
                    sender.ProcessHttpResponse<string>(httpresponse, MessagesHelper.StandartNotFoundMessage))
                .ReturnsAsync(mockResponse);
            RepositoryService repoService = new RepositoryService(mock.Object);
            ClientResponse<string> testResponse = repoService.CreateRepository(null).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }

        /// <summary>
        /// Test CreateRepository if Nameof repository is empty.
        /// </summary>
        [Fact]
        public void TestEmptyNameInCreation()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
            var mock = new Mock<IRequestSender>();
            var url = $"/{UrlConstants.UsersUrlPart}/{UrlConstants.RepositoriesUrlPart}";
            var mockResponse = new ClientResponse<string>()
            {
                Message = MessagesHelper.StandartSuccessMessage,
                Status = OperationStatus.Susseess
            };

            mock.Setup(sender => sender.SendGetRequestToGitHubApiAsync(url))
                .ReturnsAsync(httpResponseMessage);
            mock.Setup(sender =>
                    sender.ProcessHttpResponse<string>(httpResponseMessage, MessagesHelper.StandartNotFoundMessage))
                .ReturnsAsync(mockResponse);
            RepositoryService repoService = new RepositoryService(mock.Object);
            CreateRepositoryModel createModel = new CreateRepositoryModel(string.Empty, string.Empty);
            ClientResponse<string> testResponse = repoService.CreateRepository(createModel).GetAwaiter().GetResult();
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
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
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
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
            Assert.Equal(MessagesHelper.EmptyDataMessage, testResponse.Message);
            Assert.Equal(OperationStatus.EmptyData, testResponse.Status);
        }
    }
}
