using System.Globalization;

namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Basic data of gitHub repository.
    /// </summary>
    public class BasicRepositoryData
    {
        /// <summary>
        /// Gets or sets repository owner.
        /// </summary>
        [JsonProperty("owner")]
        public BasicUserData Owner { get; set; }

        /// <summary>
        /// Gets or sets name of repository.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets repository description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
