using System;
using Printer;
using static Printer.Output;

namespace Input.Fields
{
    /// <summary>
    /// Represents an input field that presents a list of choices to the user.
    /// </summary>
    public class Choice : Field
    {
        /// <summary>
        /// The options of the list. Accepts 9 options at maximum.
        /// </summary>
        public string[] Options { get; set; }

        public Choice(string description, string[] options)
            : base(description)
        {
            if (options.Length > 9)
            {
                throw new Exception("The number of the options can't be more than 9.");
            }
            Options = options;
        }

        /// <summary>
        /// Asks and returns user input as string.
        /// </summary>
        public override string GetInput()
        {
            int input;

            Console.Clear();
            PrintDescription();
            input = NumKey.Read(1, Options.Length);
            return Options[--input];
        }

        /// <summary>
        /// Outputs the field description on the console.
        /// </summary>
        protected override void PrintDescription()
        {
            Print(lineBreaks: 1);
            Print(Description + ": ");
            Print("Press a number key to select an option:", new Colours(ConsoleColor.DarkGray));
            PrintOptions();
        }

        /// <summary>
        /// Outputs all the available options as a numbered list to the console.
        /// </summary>
        private void PrintOptions()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                Print($"{i + 1} - {Options[i]}");
            }
        }

        // Inherited, but not required for this particular class.
        protected override bool IsValid(string input) => throw new NotImplementedException();
    }
}
