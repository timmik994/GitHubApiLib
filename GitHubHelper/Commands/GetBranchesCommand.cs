using GitHubClient.Interfaces;

namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using GitHubClient;
    using GitHubClient.Model;

    /// <summary>
    /// Command that gets the branches list from repo.
    /// </summary>
    [Command("branch", "Get branches from repository.")]
    public class GetBranchesCommand : AbstractCommand
    {
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
        /// List of branches.
        /// </summary>
        private List<Branch> branches;

        /// <summary>
        /// The message from gitHub client.
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBranchesCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public GetBranchesCommand(ConsoleWorker consoleHelper, IServiceFactory serviceFactory) : base(consoleHelper, serviceFactory)
        {
        }

        /// <summary>
        /// Gets the parameters for command.
        /// </summary>
        public override void GetParameters()
        {
            this.isYourRepo = this.ConslWorker.AskBoolParam("Your repository?");
            if (!this.isYourRepo)
            {
                this.username = this.ConslWorker.AskStringParam("Enter the username ");
            }

            this.repoName = this.ConslWorker.AskStringParam("Enter name of repository");
        }

        /// <summary>
        /// Gets list of branches from one repository.
        /// </summary>
        public override void RunCommand()
        {
            //if (this.isYourRepo)
            //{
            //    this.username = this.GitHubClient.GetCurrentUser(out this.message);
            //}

            //if (this.message == GitHubApiClient.SUCCESSMESSAGE)
            //{
            //    this.branches = this.GitHubClient.GetBranchesList(this.username, this.repoName, out this.message);
            //}
        }

        /// <summary>
        /// Shows list of branches, or message if branches is null.
        /// </summary>
        public override void ShowResult()
        {
            if (this.branches == null)
            {
                this.ConslWorker.WriteInConsole(this.message);
            }
            else
            {
                this.ConslWorker.WriteInConsole("List of branches:");
                foreach (var item in this.branches)
                {
                    this.ConslWorker.WriteInConsole(item.Name);
                }
            }
        }
    }
}
