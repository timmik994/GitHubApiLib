namespace GitHubClient
{
    using System;
    using System.Globalization;
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
        /// Processes HTTP response with json data from gitHub API.
        /// De-serializes data in object with <see cref="T"/> type.
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
                    clientResponse.Message = MessageConstants.Unauthorized;
                    break;
                case HttpStatusCode.NotFound:
                    clientResponse.Status = OperationStatus.NotFound;
                    clientResponse.Message = notFoundErrorMessage;
                    break;
                case HttpStatusCode.Created:
                    clientResponse.Status = OperationStatus.Susseess;
                    clientResponse.Message = MessageConstants.SuccessOperation;
                    break;
                case HttpStatusCode.OK:
                    string jsonString = await responseMessage.Content.ReadAsStringAsync();
                    try
                    {
                        clientResponse.Status = OperationStatus.Susseess;
                        clientResponse.Message = MessageConstants.SuccessOperation;
                        clientResponse.ResponseData = JsonConvert.DeserializeObject<T>(jsonString);
                    }
                    catch (Exception)
                    {
                        clientResponse.Message = string.Format(
                            CultureInfo.InvariantCulture, 
                            MessageConstants.InvalidJsonErrorTemplate, 
                            MessageConstants.InvalidJson, 
                            jsonString);
                        clientResponse.Status = OperationStatus.Error;
                    }

                    break;
                default:
                    clientResponse.Status = OperationStatus.UnknownState;
                    clientResponse.Message = MessageConstants.UnknownError;
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
                HttpMetadataConstants.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpMetadataConstants.UserAgentHeaderName, this.userAgent);
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
                HttpMetadataConstants.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpMetadataConstants.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Get;
            var fullUrl = string.Concat(UrlConstants.BasicEndpoint, url);
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
                HttpMetadataConstants.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpMetadataConstants.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(content, Encoding.UTF8, HttpMetadataConstants.JsonContentType);
            var fullUrl = string.Concat(UrlConstants.BasicEndpoint, url);
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
                HttpMetadataConstants.AuthorithationScheme, 
                this.accessToken);
            request.Headers.Add(HttpMetadataConstants.UserAgentHeaderName, this.userAgent);
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(graphQlRequest, Encoding.UTF8);
            request.RequestUri = new Uri(UrlConstants.GraphQlEndpoint);
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                return response;
            }
        }
    }
}
