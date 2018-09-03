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
        /// Gets or sets the full data about commit.
        /// </summary>
        [JsonProperty("commit")]
        public FullCommitData CommitData { get; set; }

        /// <summary>
        /// Gets or sets commit author.
        /// </summary>
        [JsonProperty("author")]
        public BasicUserData CommitAuthor { get; set; }

        /// <summary>
        /// Gets or sets commiter
        /// </summary>
        [JsonProperty("committer")]
        public BasicUserData CommitCommiter { get; set; }

        /// <summary>
        /// Gets or sets perents of the commit.
        /// </summary>
        [JsonProperty("parents")]
        public IEnumerable<BasicCommitData> Parents { get; set; }

        /// <summary>
        /// Creates string representation of object.
        /// </summary>
        /// <returns>String representation of object.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"sha: {Sha}");
            str.AppendLine($"date: {CommitData.Commiter.Date}");
            str.AppendLine($"commiter: {CommitAuthor.Login}");
            str.AppendLine($"email: {CommitData.Commiter.Email}");
            return str.ToString();
        }
    }
}
