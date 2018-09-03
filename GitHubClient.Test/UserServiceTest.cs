namespace GitHubClient.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using GitHubClient.Interfaces;
    using GitHubClient.Model;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;

    /// <summary>
    /// Unit tests for userService class.
    /// </summary>
    public class UserServiceTest
    {
        /// <summary>
        /// Test user login.
        /// </summary>
        private const string TestUserLogin = "test";

        /// <summary>
        /// Testa that insecond request returns same user object as in first.
        /// </summary>
        [Fact]
        public void TestGetCurrentUserSecondTime()
        {
            HttpResponseMessage testResponse = this.GenerateSussessfulresponseMessage();
            FullUserData testUserObject = this.GenerateTestUser();
            ClientResponse<FullUserData> mockResponse = new ClientResponse<FullUserData>()
            {
                Message = MessagesHelper.StandartSuccessMessage,
                Status = OperationStatus.Susseess,
                ResponseData = testUserObject
            };

            var mock = new Mock<IRequestSender>();
            mock.Setup(sender => sender.SendGetRequestToGitHubApiAsync($"/{UrlConstants.CurrentUserUrlPart}"))
                .ReturnsAsync(testResponse);
            mock.Setup(sender =>
                    sender.ProcessHttpResponse<FullUserData>(testResponse, MessagesHelper.StandartNotFoundMessage))
                .ReturnsAsync(mockResponse);
            UserService userService = new UserService(mock.Object);
            ClientResponse<FullUserData> testClientResponseFirst = userService.GetCurrentUser().GetAwaiter().GetResult();
            ClientResponse<FullUserData> testClientResponseSecond = userService.GetCurrentUser().GetAwaiter().GetResult();
            Assert.Equal(testClientResponseFirst.ResponseData, testClientResponseSecond.ResponseData);
            Assert.Equal(MessagesHelper.DataAlreadyLoadedMessage, testClientResponseSecond.Message);
            mock.Verify(sender => sender.ProcessHttpResponse<FullUserData>(testResponse, MessagesHelper.StandartNotFoundMessage), Times.Once);
        }

        /// <summary>
        /// Tests GetUserData with object param if object is null.
        /// </summary>
        [Fact]
        public void TestGetUserDataIfParameterNull()
        {
            var httpresponse = new HttpResponseMessage(HttpStatusCode.NotFound);
            var mock = new Mock<IRequestSender>();
            UserService userService = new UserService(mock.Object);
            ClientResponse<FullUserData> testClientResponse = userService.GetFullUserData((BasicUserData)null).GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.EmptyData, testClientResponse.Status);
            Assert.Equal(MessagesHelper.EmptyDataMessage, testClientResponse.Message);
            Assert.Null(testClientResponse.ResponseData);
        }

        /// <summary>
        /// Tests GetUserData if passed empty string.
        /// </summary>
        [Fact]
        public void TestGetUserDataIfPassedEmptyString()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            var mock = new Mock<IRequestSender>();
            UserService userService = new UserService(mock.Object);
            ClientResponse<FullUserData> testClientResponse = userService.GetFullUserData(string.Empty).GetAwaiter().GetResult();
            Assert.Equal(OperationStatus.EmptyData, testClientResponse.Status);
            Assert.Equal(MessagesHelper.EmptyDataMessage, testClientResponse.Message);
            Assert.Null(testClientResponse.ResponseData);
        }

        /// <summary>
        /// Generates test user object.
        /// </summary>
        /// <returns>Test user object.</returns>
        private FullUserData GenerateTestUser()
        {
            var testUser = new FullUserData()
            {
                Login = UserServiceTest.TestUserLogin,
                Name = "test name",
                CreatedAt = DateTime.Now,
                Email = "testMail",
                Company = "no",
                FolloversCount = 1,
                FollowingCount = 2,
                Location = "russia",
                PublicReposCount = 4,
                URL = "url",
                UpdatedAt = DateTime.Today
            };
            return testUser;
        }

        /// <summary>
        /// Generates json string of user object.
        /// </summary>
        /// <param name="userObj">The user object.</param>
        /// <returns>Json string.</returns>
        private string GenerateUserJson(FullUserData userObj)
        {
            return JsonConvert.SerializeObject(userObj);
        }

        /// <summary>
        /// Generates sussessfui http response.
        /// </summary>
        /// <returns>Http response with status Ok.</returns>
        private HttpResponseMessage GenerateSussessfulresponseMessage()
        {
            FullUserData testUser = this.GenerateTestUser();
            string jsonString = this.GenerateUserJson(testUser);
            var respMsg = new HttpResponseMessage(HttpStatusCode.OK);
            respMsg.Content = new StringContent(jsonString);
            return respMsg;
        }
    }
}
