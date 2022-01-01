using System;
using static System.Console;
using Printer;

namespace Input
{
    /// <summary>
    /// Contains method for receiving, validating and returning user numeric input.
    /// </summary>
    public static class AskNumber
    {
        /// <summary>
        /// Receives and returns a number from the user.
        /// </summary>
        /// <param name="max">The maximum valid value.</param>
        /// <param name="description">Overrides the default input description.</param>
        /// <returns></returns>
        public static int GetInput(int max, string description = null) => GetInput(0, max, description);
        /// <summary>
        /// Receives and returns a number from the user.
        /// </summary>
        /// <param name="min">The minimum valid value.</param>
        /// <param name="max">The maximum valid value.</param>
        /// <param name="description">Overrides the default input description.</param>
        /// <returns></returns>
        public static int GetInput(int min, int max, string description = null)
        {
            (int, int) cursorPosition;

            PrintDescription(min, max, description);
            cursorPosition = (Console.CursorLeft, Console.CursorTop);
            
            return AskUser(min, max, cursorPosition);
        }

        /// <summary>
        /// Reads the input from the user.
        /// </summary>
        private static int AskUser(int min, int max, (int, int) cursorPosition)
        {
            string input = Console.ReadLine();
            int result;
            bool isNumberic = int.TryParse(input, out result);

            if (!isNumberic)
            {
                Clear(cursorPosition, input.Length);
                PrintError("Invalid input; must be numeric.");
                SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
                return AskUser(min, max, cursorPosition);
            }
            if (!IsInRange(result, min, max))
            {
                Clear(cursorPosition, input.Length);
                PrintError($"Invalid input. The number must be between {min} and {max - 1}.");
                SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
                return AskUser(min, max, cursorPosition);
            }
            return result;
        }

        /// <summary>
        /// Outputs the description on the screen.
        /// </summary>
        private static void PrintDescription(int min, int max, string description)
        {
            Colours colours = new Colours(ConsoleColor.White, ConsoleColor.DarkBlue);

            if (description is null)
            {
                Output.Print($"Enter a number between {min} and {max - 1}", colours);
            }
            else
            {
                Output.Print(description, colours);
            }
        }

        /// <summary>
        /// Clears part of the console for reprinting the output.
        /// </summary>
        /// <param name="cursorPosition"></param>
        /// <param name="length"></param>
        private static void Clear((int, int) cursorPosition, int length)
        {
            SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
            WriteLine(new String(' ', length));
        }

        /// <summary>
        /// Outputs an error message on the console.
        /// </summary>
        /// <param name="message"></param>
        private static void PrintError(string message)
        {
            Output.Print(message, new Colours(ConsoleColor.Red), lineBreaks: 0);
            WriteLine(new String(' ', 100)); // overwrites any previous output.
        }
           
        /// <summary>
        /// Validates whenever the input is within range.
        /// </summary>
        private static bool IsInRange(int num, int min, int max) => num >= min && num < max;
    }
}
