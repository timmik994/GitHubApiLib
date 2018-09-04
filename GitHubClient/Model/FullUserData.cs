namespace GitHubClient.Model
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Full data of gitHub user.
    /// </summary>
    public class FullUserData : BasicUserData
    {
        /// <summary>
        /// Gets or sets name of the user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets company of the user.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets location of the user.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user creation time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets user last update time.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets user's public repositories count.
        /// </summary>
        [JsonProperty("public_repos")]
        public int PublicReposCount { get; set; }

        /// <summary>
        /// Gets or sets user followers count.
        /// </summary>
        [JsonProperty("followers")]
        public int FolloversCount { get; set; }

        /// <summary>
        /// Gets or sets user following count.
        /// </summary>
        [JsonProperty("following")]
        public int FollowingCount { get; set; }
    }
}
