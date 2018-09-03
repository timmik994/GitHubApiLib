namespace GitHubClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// License data.
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
        /// Gets or sets license url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
