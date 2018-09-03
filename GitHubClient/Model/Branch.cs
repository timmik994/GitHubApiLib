namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Branch data gutted from branch list of git repository.
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether branch is protected.
        /// </summary>
        [JsonProperty("protected")]
        public bool IsProtected { get; set; }

        /// <summary>
        /// Gets or sets last commit.
        /// </summary>
        [JsonProperty("commit")]
        public BasicCommitData Commit { get; set; }
    }
}
