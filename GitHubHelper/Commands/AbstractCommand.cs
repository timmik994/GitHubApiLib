namespace GitHubHelper.Commands
{
    using GitHubClient;

    /// <summary>
    /// Abstract class of the command.
    /// </summary>
    public abstract class AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public AbstractCommand(ConsoleWorker consoleHelper)
        {
            this.ConslWorker = consoleHelper;
        }

        /// <summary>
        /// Gets or sets instance of ConsoleHelper class.
        /// </summary>
        protected ConsoleWorker ConslWorker { get; set; }

        /// <summary>
        /// In this methods command will ack parameters.
        /// </summary>
        public abstract void GetParameters();

        /// <summary>
        /// In this method Actions for command will be processed.
        /// </summary>
        public abstract void RunCommand();

        /// <summary>
        /// In this method results of command will be shown in console.
        /// </summary>
        public abstract void ShowResult();
    }
}
