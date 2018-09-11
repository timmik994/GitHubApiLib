namespace GitHubHelper
{
    using System;

    /// <summary>
    /// Worker to work with console.
    /// </summary>
    public class ConsoleWorker
    {
        /// <summary>
        /// String of yes answer.
        /// </summary>
        private const string YesAnswer = "yes";

        /// <summary>
        /// String of no answer.
        /// </summary>
        private const string NoAnswer = "no";

        /// <summary>
        /// Message about empty string from user.
        /// </summary>
        private const string EmptyStringMessage = "Please write non empty string.";

        /// <summary>
        /// Asks boolean param from user.
        /// </summary>
        /// <param name="question">Question about param.</param>
        /// <returns>Bool param from user.</returns>
        public virtual bool AskBoolParam(string question)
        {
            Console.WriteLine(question);
            do
            {
                Console.WriteLine("Print [yes/no]");
                string answer = Console.ReadLine();
                if (answer == ConsoleWorker.YesAnswer)
                {
                    return true;
                }

                if (answer == ConsoleWorker.NoAnswer)
                {
                    return false;
                }
            }
            while (true);
        }

        /// <summary>
        /// Asks string param from user.
        /// </summary>
        /// <param name="question">Question about param.</param>
        /// <returns>String entered by user.</returns>
        public virtual string AskStringParam(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            while (answer == string.Empty)
            {
                Console.WriteLine(ConsoleWorker.EmptyStringMessage);
                answer = Console.ReadLine();
            }

            return answer;
        }

        /// <summary>
        /// Writes message in console.
        /// </summary>
        /// <param name="message">Mesage to write.</param>
        public virtual void WriteInConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
