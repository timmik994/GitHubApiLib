namespace GitHubHelper
{
    using System;

    /// <summary>
    /// Attribute that indicates comand class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttribute" /> class.
        /// </summary>
        /// <param name="commandString">String to call command.</param>
        /// <param name="description">Description of command.</param>
        public CommandAttribute(string commandString, string description)
        {
            this.CommandDescription = description;
            this.CommandString = commandString;
        }

        /// <summary>
        /// Gets or sets string to call this command.
        /// </summary>
        public string CommandString { get; set; }

        /// <summary>
        /// Gets or sets description of the command.
        /// </summary>
        public string CommandDescription { get; set; }
    }
}
