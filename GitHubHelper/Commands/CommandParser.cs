namespace GitHubHelper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parser of the console commands.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// Reg expression of parameter name.
        /// </summary>
        public const string ParamRegexp = "--?";

        /// <summary>
        /// Parses command.
        /// </summary>
        /// <param name="command">Command string.</param>
        /// <returns>Data of the command.</returns>
        public static CommandData ParseCommand(string command)
        {
            string[] commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CommandData data = new CommandData();
            data.DataType = commandParts[0];
            data.Action = commandParts[1];
            data.Parameters = new Dictionary<string, string>();
            for (int i = 2; i < commandParts.Length; i++)
            {
                Regex param = new Regex(CommandParser.ParamRegexp);
                bool isParamName = param.IsMatch(commandParts[i]);
                commandParts[i] = commandParts[i].Replace("-", string.Empty);
                if (isParamName)
                {
                    // If parameter name is last in the string his value is empty.
                    if (i + 1 == commandParts.Length)
                    {
                        data.Parameters.Add(commandParts[i], string.Empty);
                    }
                    else
                    {
                        bool isNextElementParam = param.IsMatch(commandParts[i + 1]);
                        if (isNextElementParam)
                        {
                            data.Parameters.Add(commandParts[i], string.Empty);
                        }
                        else
                        {
                            data.Parameters.Add(commandParts[i], commandParts[i + 1]);
                        }
                    }
                }
            }

            return data;
        }
    }
}
