namespace GitHubHelper.Commands
{
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command to get repositories of branch.
    /// </summary>
    [Command("commits", "Get commits in branch.")]
    public class BranchCommitsCommand : AbstractCommand
    {
        /// <summary>
        /// String that prints between commits.
        /// </summary>
        private const string COMMITDELIMETER = "_________________________";

        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// Is current user is owner of repository.
        /// </summary>
        private bool isYourRepo;

        /// <summary>
        /// The name of the repo.
        /// </summary>
        private string repoName;

        /// <summary>
        /// The name of the branch.
        /// </summary>
        private string branchName;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// The list of commits from git hub.
        /// </summary>
        private List<Commit> commits;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchCommitsCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public BranchCommitsCommand(ConsoleWorker consoleHelper) : base(consoleHelper)
        {
        }

        /// <summary>
        /// Get the parameters to run command.
        /// </summary>
        public override void GetParameters()
        {
            //this.isYourRepo = this.ConslWorker.AskBoolParam("Your repository?");
            //if (!this.isYourRepo)
            //{
            //    this.username = this.ConslWorker.AskStringParam("Enter the username");
            //}

            //this.repoName = this.ConslWorker.AskStringParam("Enter name of repository");
            //this.branchName = this.ConslWorker.AskStringParam("Enter the branch name");
        }

        /// <summary>
        /// Gets the list of commits from branch.
        /// </summary>
        public override void RunCommand()
        {
            //if (this.isYourRepo)
            //{
            //    this.username = this.GitHubClient.GetCurrentUser(out this.message);
            //}

            //if (this.message == GitHubApiClient.SUCCESSMESSAGE)
            //{
            //    this.commits =
            //        this.GitHubClient.GetBranchCommits(this.username, this.repoName, this.branchName, out this.message);
            //}
        }

        /// <summary>
        /// Shows list of commits or message if commits is null.
        /// </summary>
        public override void ShowResult()
        {
            //if (this.commits == null)
            //{
            //    this.ConslWorker.WriteInConsole(this.message);
            //}
            //else
            //{
            //    this.ConslWorker.WriteInConsole("commits:");
            //    foreach (var item in this.commits)
            //    {
            //        this.ConslWorker.WriteInConsole(BranchCommitsCommand.COMMITDELIMETER);
            //        this.ConslWorker.WriteInConsole(item.ToString());
            //    }
            //}
        }
    }
}
