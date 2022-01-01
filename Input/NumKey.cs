using System;

namespace Input
{
    /// <summary>
    /// Contains methods to read number keys from user input.
    /// </summary>
    public static class NumKey
    {
        /// <summary>
        /// Reads a number key and returns it's corresponding int value.
        /// </summary>
        /// <param name="min">The minimum number key value.</param>
        /// <param name="max">The maximum number key value.</param>
        /// <param name="canEscape">True, if the espace key should be included as possible input.</param>
        public static int Read(int min = 1, int max = 9, bool canEscape = false)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1: return Validate(1, min, max, canEscape);
                case ConsoleKey.D2: return Validate(2, min, max, canEscape);
                case ConsoleKey.D3: return Validate(3, min, max, canEscape);
                case ConsoleKey.D4: return Validate(4, min, max, canEscape);
                case ConsoleKey.D5: return Validate(5, min, max, canEscape);
                case ConsoleKey.D6: return Validate(6, min, max, canEscape);
                case ConsoleKey.D7: return Validate(7, min, max, canEscape);
                case ConsoleKey.D8: return Validate(8, min, max, canEscape);
                case ConsoleKey.D9: return Validate(9, min, max, canEscape);
                case ConsoleKey.Escape: return canEscape ? 0 : Read(min, max);
                default: return Read(min, max);
            }
        }

        private static int Validate(int value, int min, int max, bool canEscape)
        {
            bool inRange = value >= min && value <= max;
            return inRange ? value : Read(min, max, canEscape);
        }
    }
}