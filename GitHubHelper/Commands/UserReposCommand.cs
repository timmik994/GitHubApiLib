namespace GitHubHelper.Commands
{
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command, that gets repositories of specified user.
    /// </summary>
    [Command("userepos", "Get repositories from specified user.")]
    public class UserReposCommand : AbstractCommand
    {
        /// <summary>
        /// The repositories getted from github.
        /// </summary>
        //private List<Repository> repositories;

        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// The message from client;
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserReposCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public UserReposCommand(ConsoleWorker consoleHelper) : base(consoleHelper)
        {
        }

        /// <summary>
        /// Asks the username.
        /// </summary>
        public override void GetParameters()
        {
            this.username = this.ConslWorker.AskStringParam("Enter the username");
        }
        
        /// <summary>
        /// Gets the repositories.
        /// </summary>
        public override void RunCommand()
        {
            //this.repositories = this.GitHubClient.GetUserRepositories(this.username, out this.message);
        }

        /// <summary>
        /// Shows list of repositories or message if repositories list is null.
        /// </summary>
        public override void ShowResult()
        {
            //if (this.repositories == null)
            //{
            //    this.ConslWorker.WriteInConsole(this.message);
            //}
            //else
            //{
            //    foreach (var repo in this.repositories)
            //    {
            //        this.ConslWorker.WriteInConsole(repo.ToString());
            //    }
            //}
        }
    }
}
