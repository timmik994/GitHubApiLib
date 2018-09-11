namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Basic data of gitHub User.
    /// </summary>
    public class BasicUserData
    {
        /// <summary>
        /// Gets or sets login of the user.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets URL of user page on github.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
