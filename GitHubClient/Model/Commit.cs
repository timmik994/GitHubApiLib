namespace GitHubClient.Model
{
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Commit in gitHub repository.
    /// </summary>
    public class Commit
    {
        /// <summary>
        /// Gets or sets sha of commit.
        /// </summary>
        [JsonProperty("sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Gets or sets full data about commit.
        /// </summary>
        [JsonProperty("commit")]
        public FullCommitData CommitData { get; set; }

        /// <summary>
        /// Gets or sets commit author.
        /// </summary>
        [JsonProperty("author")]
        public BasicUserData CommitAuthor { get; set; }

        /// <summary>
        /// Gets or sets committer
        /// </summary>
        [JsonProperty("committer")]
        public BasicUserData CommitCommiter { get; set; }

        /// <summary>
        /// Gets or sets parents of the commit.
        /// </summary>
        [JsonProperty("parents")]
        public IEnumerable<BasicCommitData> Parents { get; set; }
    }
}
