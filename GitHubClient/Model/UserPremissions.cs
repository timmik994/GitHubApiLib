namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// User permissions in repository.
    /// </summary>
    public class UserPremissions
    {
        /// <summary>
        /// Gets or sets a value indicating whether current user
        /// has admin privileges.
        /// </summary>
        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether current user
        /// can push in this repository.
        /// </summary>
        [JsonProperty("push")]
        public bool CanPush { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether current user
        /// can pull this repository.
        /// </summary>
        [JsonProperty("pull")]
        public bool CanPull { get; set; }
    }
}
