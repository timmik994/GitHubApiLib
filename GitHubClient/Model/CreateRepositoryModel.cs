namespace GitHubClient.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Data that we send to server to create new repository.
    /// </summary>
    public class CreateRepositoryModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRepositoryModel" /> class.
        /// </summary>
        /// <param name="name">Name of the repository.</param>
        /// <param name="description">Description of new repository.</param>
        public CreateRepositoryModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets name of the repository.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description of new repository.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
