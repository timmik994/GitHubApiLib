namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that get repos of current user.
    /// </summary>
    [Command("myrepos", "Get your repositories.")]
    public class MyReposCommand : AbstractCommand
    {
        /// <summary>
        /// The repositories getted from github.
        /// </summary>
        //private List<Repository> repositories;

        /// <summary>
        /// The message from client;
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyReposCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public MyReposCommand(ConsoleWorker consoleHelper) : base(consoleHelper)
        {
        }

        /// <summary>
        /// Asks username from user.
        /// </summary>
        public override void GetParameters()
        {
        }

        /// <summary>
        /// Gets the repositories list from gitHub.
        /// </summary>
        public override void RunCommand()
        {
            //this.repositories = this.GitHubClient.GetMyRepositories(out this.message);
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
            //    IEnumerable<string> reposData = this.repositories.Select(rep => rep.ToString());
            //    foreach (var resp in reposData)
            //    {
            //        this.ConslWorker.WriteInConsole(resp);
            //    }
            //}
        }
    }
}
