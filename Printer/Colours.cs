using System;

namespace Printer
{
    /// <summary>
    /// Stores a foreground and background console colour pair.
    /// </summary>
    public class Colours
    {
        /// <summary>
        /// The foreground console colour.
        /// </summary>
        public ConsoleColor Foreground { get; set; }
        /// <summary>
        /// The background console colour.
        /// </summary>
        public ConsoleColor Background { get; set; }

        public Colours(
            ConsoleColor foreground = ConsoleColor.White,
            ConsoleColor background = ConsoleColor.Black)
        {
            Foreground = foreground;
            Background = background;
        }

        /// <summary>
        /// Applies the object's foreground and background colours to the console.
        /// </summary>
        public void Apply()
        {
            Console.ForegroundColor = Foreground;
            Console.BackgroundColor = Background;
        }
    }
}
