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
        /// Sends GET request to absolute URl.
        /// </summary>
        /// <param name="url">The absolute URL.</param>
        /// <returns>HTTP response message.</returns>
        Task<HttpResponseMessage> SendGetRequestToAbsoluteUrlAsync(string url);

        /// <summary>
        /// Sends GET request to basic git hub API endpoint.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <returns>HTTP response message.</returns>
        Task<HttpResponseMessage> SendGetRequestToGitHubApiAsync(string url);

        /// <summary>
        /// Sends POST request to basic git hub API endpoint.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <param name="content">The content to send in request.</param>
        /// <returns>HTTP response message.</returns>
        Task<HttpResponseMessage> SendPostRequestToGitHubApiAsync(string url, string content);

        /// <summary>
        /// Send request to GraphQl gitHub API endpoint.
        /// </summary>
        /// <param name="graphQlRequest">The graphQl request.</param>
        /// <returns>HTTP response message.</returns>
        Task<HttpResponseMessage> SendRequestToGraphQlEndpointAsync(string graphQlRequest);
    }
}
