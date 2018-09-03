namespace GitHubHelper
{
    using System;
    using GitHubClient;
    using GitHubHelper.Commands;

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Const string to write between commands.
        /// </summary>
        public const string DelimeterMessage = "-----------------------------------------------------";

        /// <summary>
        /// Message to say hello to user.
        /// </summary>
        private const string StartMessage = "Hello from GitHubHelper. Please enter help to see instructions.";

        /// <summary>
        /// Gets or sets a value indicating whether program need continue running.
        /// </summary>
        public static bool ContinueRunning { get; set; }

        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">String of arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine(Program.DelimeterMessage);
            Console.WriteLine("Please enter access token");
            string token = Console.ReadLine();
            Console.WriteLine(Program.DelimeterMessage);
            Console.WriteLine(Program.StartMessage);
            //GitHubApiClient gitHubClient = GitHubApiClient.GetInstance();
            //gitHubClient.SetAccessToken(token);
            ContinueRunning = true;
            var commandFactory = new CommandFactory();
            while (ContinueRunning)
            {
                Console.WriteLine(Program.DelimeterMessage);
                Console.Write(">>>");
                string command = Console.ReadLine();
                ProcessCommand(command, commandFactory);
            }
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="command">The command from user.</param>
        /// <param name="commandFactory">The instance of CommandFactory.</param>
        public static void ProcessCommand(string command, CommandFactory commandFactory)
        {
            AbstractCommand commandInstance = commandFactory.GetCommand(command);
            if (commandInstance != null)
            {
                commandInstance.GetParameters();
                commandInstance.RunCommand();
                commandInstance.ShowResult();
            }
            else
            {
                Console.WriteLine($"Command '{command}' is invalid. Enter help to get instructions.");
            }
        }
    }
}
