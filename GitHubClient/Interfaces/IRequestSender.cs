namespace GitHubClient.Interfaces
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Methods to send request to gitHub.
    /// </summary>
    public interface IRequestSender
    {
        /// <summary>
        /// Sends GETrequest to absolute URl.
        /// </summary>
        /// <param name="url">The absolute url.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendGetRequestToAbsoluteUrlAsync(string url);

        /// <summary>
        /// Sends GET request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendGetRequestToGitHubApiAsync(string url);

        /// <summary>
        /// Sends POST request to basic git hub api endpoint.
        /// </summary>
        /// <param name="url">The relative url.</param>
        /// <param name="content">Content to send in request.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendPostRequestToGitHubApiAsync(string url, string content);

        /// <summary>
        /// Send request to GraphQl gitHub api endpoint.
        /// </summary>
        /// <param name="graphQlRequest">GraphQl request.</param>
        /// <returns>Http response message.</returns>
        Task<HttpResponseMessage> SendRequestToGraphQlEndpointAsync(string graphQlRequest);

        /// <summary>
        /// Method that processes http response.
        /// </summary>
        /// <typeparam name="T">Type of data in ClientResponse.</typeparam>
        /// <param name="responseMessage">The http response message.</param>
        /// <param name="notFoundErrorMessage">The message shown if status code is NotFound.</param>
        /// <returns>ClientResponse instance with status and parsed data.</returns>
        Task<ClientResponse<T>> ProcessHttpResponse<T>(HttpResponseMessage responseMessage,string notFoundErrorMessage);
    }
}
