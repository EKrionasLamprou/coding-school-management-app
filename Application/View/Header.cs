using System;
using Printer;

namespace SCS.View
{
    /// <summary>
    /// A header with the school's brand.
    /// </summary>
    static class Header
    {
        static string[][] brand = new string[3][]
        {
            new string[] {"SPA", "GH", "ETI"},
            new string[] {" CO", "DI", "NG "},
            new string[] {" SC", "HO", "OL "},
        };
        static Colours[] colours = new Colours[3]
        {
            new Colours(ConsoleColor.Green),
            new Colours(ConsoleColor.White),
            new Colours(ConsoleColor.Red),
        };

        /// <summary>
        /// Prints the header on the console.
        /// </summary>
        /// <param name="delay">Delay in milliseconds between the syllables.</param>
        public static void Render(int delay = 0)
        {
            Console.Clear();
            foreach (string[] word in brand)
            {
                for (int i = 0; i < 3; i++)
                {
                    Output.Print(word[i], colours[i], 0, delay);
                }
                Output.Print(lineBreaks: 1);
            }
            Output.Print(lineBreaks: 2);
        }
    }
}
