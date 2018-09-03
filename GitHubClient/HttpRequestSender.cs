namespace GitHubClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using GitHubClient.Interfaces;
    using Newtonsoft.Json;

    /// <summary>
    /// Sender of HTTP requests to gitHub API endpoints.
    /// </summary>
    public class HttpRequestSender : IRequestSender
    {
        /// <summary>
        /// The URL of basic gitHub endpoint.
        /// </summary>
        public const string BasicEndpoint = "https://api.github.com";

        /// <summary>
        /// The URL of graphQl gitHub endpoint.
        /// </summary>
        public const string GraphQlEndpoint = "https://api.github.com/graphql";

        /// <summary>
        /// The scheme of authorization.
        /// </summary>
        public const string AuthorithationScheme = "Bearer";

        /// <summary>
        /// The name of user agent header.
        /// </summary>
        public const string UserAgentHeaderName = "User-Agent";

        /// <summary>
        /// The access token from gitHub.
        /// </summary>
        private string accessToken;

        /// <summary>
        /// The user agent header value.
        /// </summary>
        private string userAgent;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSender" /> class.
        /// </summary>
        /// <param name="accessToken">The access token from gitHub.</param>
        /// <param name="userAgent">The user agent header value.</param>
        public HttpRequestSender(string accessToken, string userAgent = "c#App")
        {
            this.accessToken = accessToken;
            this.userAgent = userAgent;
        }

        /// <summary>
        /// Method that processes HTTP response that returned some data.
        /// </summary>
        /// <typeparam name="T">Type of data in ClientResponse.</typeparam>
        /// <param name="responseMessage">The HTTP response message.</param>
        /// <param name="notFoundErrorMessage">The message shown if status code is NotFound.</param>
        /// <returns>ClientResponse instance with status and parsed data.</returns>
        public async Task<ClientResponse<T>> ProcessHttpResponse<T>(
            HttpResponseMessage responseMessage, 
            string notFoundErrorMessage)
        {
            ClientResponse<T> clientResponse = new ClientResponse<T>();
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    clientResponse.Status = OperationStatus.Error;
                    clientResponse.Message = MessagesHelper.UnauthorizedMessage;
                    break;
                case HttpStatusCode.NotFound:
                    clientResponse.Status = OperationStatus.NotFound;
                    clientResponse.Message = notFoundErrorMessage;
                    break;
                case HttpStatusCode.Created:
                    clientResponse.Status = OperationStatus.Susseess;
                    clientResponse.Message = MessagesHelper.StandartSuccessMessage;
                    break;
                case HttpStatusCode.OK:
                    clientResponse.Status = OperationStatus.Susseess;
                    clientResponse.Message = MessagesHelper.StandartSuccessMessage;
                    string jsonString = await responseMessage.Content.ReadAsStringAsync();
                    try
                    {
                        clientResponse.ResponseData = JsonConvert.DeserializeObject<T>(jsonString);
                    }
                    catch (Exception)
                    {
                        clientResponse.Message = $"{MessagesHelper.InvalidJsonMessage}: {jsonString}";
                        clientResponse.Status = OperationStatus.Error;
                    }

                    break;
                default:
                    clientResponse.Status = OperationStatus.UnknownState;
                    clientResponse.Message = MessagesHelper.UnknownErrorMessage;
                    break;
            }

            return clientResponse;
        }

        /// <summary>
        /// Sends GET HTTP request to absolute URl passed as parameter..
        /// </summary>
        /// <param name="url">The absolute URL.</param>
        /// <returns>HTTP response message.</returns>
        public async Task<HttpResponseMessage> SendGetRequestToAbsoluteUrlAsync(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue(
                HttpRequestSender.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpRequestSender.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return response;
            }
        }

        /// <summary>
        /// Sends GET request to gitHub API.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <returns>Response message.</returns>
        public async Task<HttpResponseMessage> SendGetRequestToGitHubApiAsync(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue(
                HttpRequestSender.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpRequestSender.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Get;
            var fullUrl = $"{HttpRequestSender.BasicEndpoint}{url}";
            request.RequestUri = new Uri(fullUrl);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return response;
            }
        }

        /// <summary>
        /// Sends POST request to gitHub API.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <param name="content">The content to send in gitHub.</param>
        /// <returns>Response message.</returns>
        public async Task<HttpResponseMessage> SendPostRequestToGitHubApiAsync(string url, string content)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue(
                HttpRequestSender.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpRequestSender.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var fullUrl = $"{HttpRequestSender.BasicEndpoint}{url}";
            request.RequestUri = new Uri(fullUrl);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return response;
            }
        }

        /// <summary>
        /// Sends request to gitHub API graohQl endpoint.
        /// </summary>
        /// <param name="graphQlRequest">The graphQl request.</param>
        /// <returns>Response message.</returns>
        public async Task<HttpResponseMessage> SendRequestToGraphQlEndpointAsync(string graphQlRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Authorization = new AuthenticationHeaderValue(
                HttpRequestSender.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpRequestSender.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(graphQlRequest, Encoding.UTF8);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return response;
            }
        }
    }
}
