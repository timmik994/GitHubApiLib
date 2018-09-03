namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that gets count of commits.
    /// </summary>
    [Command("commitscount", "Returns count of commits.")]
    public class CommitCountCommand : AbstractCommand
    {
        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// Is calculates count in all repositories in user list.
        /// </summary>
        private bool inAllRepos;

        /// <summary>
        /// Is current user is owner of repository.
        /// </summary>
        private bool isYourRepo;

        /// <summary>
        /// The name of the repo.
        /// </summary>
        private string repoName;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// Count of commits.
        /// </summary>
        private int commitsCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommitCountCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public CommitCountCommand(ConsoleWorker consoleHelper) : base(consoleHelper)
        {
        }

        /// <summary>
        /// Gets the parameters to run command.
        /// </summary>
        public override void GetParameters()
        {
            this.inAllRepos = this.ConslWorker.AskBoolParam("In all repositories?");
            if (!this.inAllRepos)
            {
                this.repoName = this.ConslWorker.AskStringParam("Enter name of repository");
                this.isYourRepo = this.ConslWorker.AskBoolParam("Your repository?");
                if (!this.isYourRepo)
                {
                    this.username = this.ConslWorker.AskStringParam("Enter repository owner");
                }
            }
        }

        /// <summary>
        /// If repoName is not empty we get count of commits from that repo.
        /// Otherwise we get commits from all your repos.
        /// </summary>
        public override void RunCommand()
        {
            //if (this.isYourRepo)
            //{
            //    this.username = this.GitHubClient.GetCurrentUser(out this.message);
            //    if (this.message != GitHubApiClient.SUCCESSMESSAGE)
            //    {
            //        return;
            //    }
            //}

            //if (!this.inAllRepos)
            //{
            //    this.commitsCount = this.GetCommitCountInRepo(this.repoName, this.username);
            //}
            //else
            //{
            //    List<Repository> repositories = this.GitHubClient.GetMyRepositories(out this.message);
            //    if (repositories != null)
            //    {
            //        foreach (var repo in repositories)
            //        {
            //            this.commitsCount += this.GetCommitCountInRepo(repo.Name, repo.Owner.Login);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// If all requests are successful Shows count of commits.
        /// Otherwise says that something is wrong.
        /// </summary>
        public override void ShowResult()
        {
            //if (this.message == GitHubApiClient.SUCCESSMESSAGE)
            //{
            //    this.ConslWorker.WriteInConsole($"Count of commits: {this.commitsCount}");
            //}
            //else
            //{
            //    this.ConslWorker.WriteInConsole("The are some problems with requests.");
            //}
        }

        /// <summary>
        /// Gets commit count from specified repository.
        /// </summary>
        /// <param name="repositoryName">The name of repository.</param>
        /// <param name="ownreUsername">the usernameof repository owner.</param>
        /// <returns>Count of commits in repository.</returns>
        private int GetCommitCountInRepo(string repositoryName, string ownreUsername)
        {
            //List<Commit> commits = this.GitHubClient.GetReposiroryCommits(ownreUsername, repositoryName, out this.message);
            //if (commits != null)
            //{
            //    return commits.Count;
            //}
            //else
            //{
            //    return 0;
            //}
            return 0;
        }
    }
}
