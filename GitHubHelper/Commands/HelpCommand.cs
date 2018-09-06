using GitHubClient.Interfaces;

namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using GitHubClient;

    /// <summary>
    /// Command that shows instructions.
    /// </summary>
    [Command("help", "show instructions.")]
    public class HelpCommand : AbstractCommand
    {
        /// <summary>
        /// Help message to show to users.
        /// </summary>
        private string helpmessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand" /> class.
        /// </summary>
        /// <param name="consoleHelper">The ConsoleHelper instance.</param>
        /// <param name="gitHubClient">The GitHubClient instance.</param>
        public HelpCommand(ConsoleWorker consoleHelper, IServiceFactory serviceFactory) : base(consoleHelper, serviceFactory)
        {
        }

        /// <summary>
        /// Don't do anything.
        /// </summary>
        public override void GetParameters()
        {
        }

        /// <summary>
        /// Builds the help message.
        /// </summary>
        public override void RunCommand()
        {
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            List<Type> commandClasses = new List<Type>();
            foreach (var assembly in assemblies)
            {
                List<Type> comandTypes = assembly.GetTypes().Where(tp => tp.IsSubclassOf(typeof(AbstractCommand))).ToList();
                commandClasses.AddRange(comandTypes);
            }

            StringBuilder helpStringBuilder = new StringBuilder();
            foreach (var commandClass in commandClasses)
            {
                CommandAttribute attr = commandClass.GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute;
                helpStringBuilder.AppendLine($"{attr.CommandString}: {attr.CommandDescription}");
            }

            this.helpmessage = helpStringBuilder.ToString();
        }

        /// <summary>
        /// Shows help message.
        /// </summary>
        public override void ShowResult()
        {
            this.ConslWorker.WriteInConsole(this.helpmessage);
        }
    }
}
