namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Repository license data.
    /// </summary>
    public class License
    {
        /// <summary>
        /// Gets or sets key of the license.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets name of the license.
        /// </summary>
        [JsonProperty("name")]
        public string LicenseName { get; set; }

        /// <summary>
        /// Gets or sets spdx id.
        /// </summary>
        [JsonProperty("spdx_id")]
        public string SpdxId { get; set; }

        /// <summary>
        /// Gets or sets license URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
