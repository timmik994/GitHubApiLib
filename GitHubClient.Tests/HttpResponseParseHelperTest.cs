namespace GitHubClient.Tests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using GitHubClient.Model;
    using Newtonsoft.Json;
    using Xunit;

    /// <summary>
    /// Tests of HttpRequestSender class.
    /// </summary>
    public class HttpResponseParseHelperTest
    {
        /// <summary>
        /// Test message for NotFound (404) status code.
        /// </summary>
        private const string TestNotFoundMessage = "not found point reached";

        /// <summary>
        /// Username for tests.
        /// </summary>
        private const string TestUsername = "testuser";

        /// <summary>
        /// Tests process HTTP response with NotFound status code. 
        /// </summary>
        [Fact]
        public void TestProcessResponseWithNotFoundStatusCode()
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound);
            ClientResponse<string> testResponse = HttpResponceParseHelper.ProcessHttpResponse<string>(
                message, 
                HttpResponseParseHelperTest.TestNotFoundMessage)
                .GetAwaiter()
                .GetResult();
            Assert.Equal(HttpResponseParseHelperTest.TestNotFoundMessage, testResponse.Message);
            Assert.Equal(OperationStatus.NotFound, testResponse.Status);
            Assert.Null(testResponse.ResponseData);
        }

        /// <summary>
        /// Tests process response with unauthorized status code.
        /// </summary>
        [Fact]
        public void TestProcessResponseWithUnauthorizedCode()
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            ClientResponse<string> testResponse = HttpResponceParseHelper.ProcessHttpResponse<string>(
                message, 
                HttpResponseParseHelperTest.TestNotFoundMessage)
                .GetAwaiter()
                .GetResult();
            Assert.Equal(MessageConstants.Unauthorized, testResponse.Message);
            Assert.Equal(OperationStatus.Error, testResponse.Status);
            Assert.Null(testResponse.ResponseData);
        }

        /// <summary>
        /// Tests process response with unknown status code.
        /// </summary>
        [Fact]
        public void TestProcessResponseWithUnknownError()
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            ClientResponse<string> testResponse = HttpResponceParseHelper.ProcessHttpResponse<string>(
                message, 
                HttpResponseParseHelperTest.TestNotFoundMessage)
                .GetAwaiter()
                .GetResult();
            Assert.Equal(MessageConstants.UnknownError, testResponse.Message);
            Assert.Equal(OperationStatus.UnknownState, testResponse.Status);
            Assert.Null(testResponse.ResponseData);
        }

        /// <summary>
        /// Tests process response with created code.
        /// </summary>
        [Fact]
        public void TestProcessResponseWithCreatedCode()
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Created);
            ClientResponse<string> testResponse = HttpResponceParseHelper.ProcessHttpResponse<string>(
                message, 
                HttpResponseParseHelperTest.TestNotFoundMessage)
                .GetAwaiter()
                .GetResult();
            Assert.Equal(MessageConstants.SuccessOperation, testResponse.Message);
            Assert.Equal(OperationStatus.Susseess, testResponse.Status);
            Assert.Null(testResponse.ResponseData);
        }

        /// <summary>
        /// Tests process response if server returns valid single json.
        /// </summary>
        [Fact]
        public void TestProcessResponseWithSingleDataUnit()
        {
            BasicUserData testUserData = new BasicUserData()
            {
                Login = HttpResponseParseHelperTest.TestUsername,
                URL = "testUrl"
            };
            string userJson = JsonConvert.SerializeObject(testUserData);
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(userJson);
            ClientResponse<BasicUserData> testResponse = HttpResponceParseHelper.ProcessHttpResponse<BasicUserData>(
                message, 
                HttpResponseParseHelperTest.TestNotFoundMessage)
                .GetAwaiter()
                .GetResult();
            Assert.Equal(MessageConstants.SuccessOperation, testResponse.Message);
            Assert.Equal(OperationStatus.Susseess, testResponse.Status);
            BasicUserData userDataAfterProcess = testResponse.ResponseData;
            Assert.Equal(HttpResponseParseHelperTest.TestUsername, userDataAfterProcess.Login);
        }

        /// <summary>
        /// Tests process response if server returns valid collection of data.
        /// </summary>
        [Fact]
        public void TestProcessResponseWithDataCollection()
        {
            List<BasicUserData> testUsersList = new List<BasicUserData>();
            testUsersList.Add(new BasicUserData()
            {
                Login = "user1",
                URL = "url1"
            });
            testUsersList.Add(new BasicUserData()
            {
                Login = "user2",
                URL = "url2"
            });
            string listJson = JsonConvert.SerializeObject(testUsersList);
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(listJson);
            ClientResponse<IEnumerable<BasicUserData>> testResponse =
                HttpResponceParseHelper.ProcessHttpResponse<IEnumerable<BasicUserData>>(
                    message, 
                    HttpResponseParseHelperTest.TestNotFoundMessage)
                    .GetAwaiter()
                    .GetResult();
            Assert.Equal(MessageConstants.SuccessOperation, testResponse.Message);
            Assert.Equal(OperationStatus.Susseess, testResponse.Status);
            IEnumerable<BasicUserData> testUsersCollection = testResponse.ResponseData;
            Assert.Equal(2, testUsersCollection.Count());
        }

        /// <summary>
        ///  Tests process response if server returns invalid json.
        /// </summary>
        [Fact]
        public void TestProcesResponseWithInvalidJson()
        {
            string invalidJson = "invalid json";
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(invalidJson);
            ClientResponse<BasicUserData> testResponse =
                HttpResponceParseHelper.ProcessHttpResponse<BasicUserData>(
                    message, 
                    HttpResponseParseHelperTest.TestNotFoundMessage)
                    .GetAwaiter()
                    .GetResult();
            string expextedMessage = string.Format(
                CultureInfo.InvariantCulture, 
                "{0}: {1}",
                MessageConstants.InvalidJson, 
                invalidJson);
            Assert.Equal(expextedMessage, testResponse.Message);
            Assert.Equal(OperationStatus.Error, testResponse.Status);
        }
    }
}
