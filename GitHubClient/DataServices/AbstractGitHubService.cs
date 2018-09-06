namespace GitHubClient.DataServices
{
    using GitHubClient.Interfaces;

    /// <summary>
    /// Base class for services that works with gitHub.
    /// </summary>
    public class AbstractGitHubService
    {
        /// <summary>
        /// Gets or sets request sender to send requests to gitHub API.
        /// </summary>
        protected IRequestSender requestSender { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractGitHubService" /> class.
        /// </summary>
        /// <param name="requestSender">The request sender.</param>
        public AbstractGitHubService(IRequestSender requestSender)
        {
            this.requestSender = requestSender;
        }
    }
}
