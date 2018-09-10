namespace GitHubHelper.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Data of the command from console;
    /// </summary>
    public class CommandData
    {
        /// <summary>
        /// Gets or sets type of data that command works with.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets Action of the command.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets dictionary of parameters with long names.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}
