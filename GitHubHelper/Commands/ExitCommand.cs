namespace GitHubHelper.Commands
{
    using GitHubClient;

    /// <summary>
    /// Comand that exit from application.
    /// </summary>
    [Command("exit", "Exit from application.")]
    public class ExitCommand : AbstractCommand
    {
        /// <summary>
        /// Is user confirm exit.
        /// </summary>
        private bool userAgree;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public ExitCommand(ConsoleWorker consoleHelper) : base(consoleHelper)
        {
        }

        /// <summary>
        /// Get is user confirm exit.
        /// </summary>
        public override void GetParameters()
        {
            this.userAgree = this.ConslWorker.AskBoolParam("Exit app?");
        }

        /// <summary>
        /// Changes param to exit program.
        /// </summary>
        public override void RunCommand()
        {
            if (this.userAgree)
            {
                Program.ContinueRunning = false;
            }
        }

        /// <summary>
        /// Shows message to user.
        /// </summary>
        public override void ShowResult()
        {
            if (this.userAgree)
            {
                this.ConslWorker.WriteInConsole("Closing app...");
            }
        }
    }
}
