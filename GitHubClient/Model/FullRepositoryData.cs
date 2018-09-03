namespace GitHubClient.Model
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Full data of git repository.
    /// </summary>
    public class FullRepositoryData : BasicRepositoryData
    {
        /// <summary>
        /// Gets or sets full name of the repository.
        /// </summary>
        [JsonProperty("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository is private.
        /// </summary>
        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository is a fork.
        /// </summary>
        [JsonProperty("fork")]
        public bool IsFork { get; set; }

        /// <summary>
        /// Gets or sets count of the forks.
        /// </summary>
        [JsonProperty("forks_count")]
        public int ForkCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository has issues.
        /// </summary>
        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository has projects.
        /// </summary>
        [JsonProperty("has_projects")]
        public bool HasProjects { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository has a wiki.
        /// </summary>
        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository has github pages.
        /// </summary>
        [JsonProperty("has_pages")]
        public bool HasPages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository has downloads.
        /// </summary>
        [JsonProperty("has_downloads")]
        public bool HasDownloads { get; set; }

        /// <summary>
        /// Gets or sets date when repository was pushed.
        /// </summary>
        [JsonProperty("pushed_at")]
        public DateTime PushedAt { get; set; }

        /// <summary>
        /// Gets or sets date when repository was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets date when repository was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository is archived.
        /// </summary>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets current user permissions of this repository.
        /// </summary>
        [JsonProperty("permissions")]
        public UserPremissions UserPremissions { get; set; }

        /// <summary>
        /// Gets or sets repository license.
        /// </summary>
        [JsonProperty("license")]
        public License RepoLicense { get; set; }

        /// <summary>
        /// Gets or sets count of subscribers in repository.
        /// </summary>
        [JsonProperty("subscribers_count")]
        public int SubscribersCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository allows rebase merge.
        /// </summary>
        [JsonProperty("allow_rebase_merge")]
        public bool AllowRebaseMerge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository allows squash merge.
        /// </summary>
        [JsonProperty("allow_squash_merge")]
        public bool AllowSquashMerge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether repository allows merge commit.
        /// </summary>
        [JsonProperty("allow_merge_commit")]
        public bool AllowMergeCommit { get; set; }
    }
}
