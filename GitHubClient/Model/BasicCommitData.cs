namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Commit data about sha and url to get this commit.
    /// </summary>
    public class BasicCommitData
    {
        /// <summary>
        /// Gets or sets sha of the commit.
        /// </summary>
        [JsonProperty("sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Gets or sets url to get full data of this commit.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
