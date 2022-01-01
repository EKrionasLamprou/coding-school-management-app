using System;
using Printer;

namespace Input.Fields
{
    /// <summary>
    /// Base class. Represents an input field, that recieves, validates and returns user input.
    /// </summary>
    public abstract class Field
    {
        /// <summary>
        /// Represents an error message to be output on the next field print.
        /// </summary>
        protected string error = null;

        /// <summary>
        /// The description of the input.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// A text that appears as a placeholder where the user types input.
        /// </summary>
        public string Placeholder { get; set; }

        public Field(string description, string placeholder = null)
        {
            Description = description;
            Placeholder = placeholder;
        }

        /// <summary>
        /// Outputs the field description on the console.
        /// </summary>
        protected virtual void PrintDescription() =>
            Output.Print(Description + ": ", lineBreaks: 0);
            
        protected void PrintError() =>
            Output.Print(error, new Colours(ConsoleColor.Red), 1);

        /// <summary>
        /// Outputs the placeholder on the screen.
        /// </summary>
        protected void PrintPlaceholder()
        {
            (int, int) cursorPosition = (Console.CursorLeft, Console.CursorTop);
            Output.Print(Placeholder, new Colours(ConsoleColor.DarkGray));
            Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
        }

        /// <summary>
        /// Asks and returns user input as string.
        /// </summary>
        public virtual string GetInput()
        {
            string input;

            Console.Clear();

            if (error != null) PrintError();
            else Output.Print(lineBreaks: 1);

            PrintDescription();
            if (Placeholder != null) PrintPlaceholder();
            input = Console.ReadLine().Trim();

            return IsValid(input) ? input : GetInput();
        }

        /// <summary>
        /// Returns true if all the validation criteria are met.
        /// </summary>
        protected abstract bool IsValid(string input);
    }
}
