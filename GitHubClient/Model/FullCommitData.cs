namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Full data about commit inside commit object.
    /// </summary>
    public class FullCommitData : BasicCommitData
    {
        /// <summary>
        /// Gets or sets commiter.
        /// </summary>
        [JsonProperty("commiter")]
        public Commiter Commiter { get; set; }

        /// <summary>
        /// Gets or sets author of the commit.
        /// </summary>
        [JsonProperty("author")]
        public Commit Author { get; set; }

        /// <summary>
        /// Gets or sets commit message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets count of comments on this commit.
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets data of the tree in commit.
        /// </summary>
        [JsonProperty("tree")]
        public BasicCommitData Tree { get; set; }
    }
}
