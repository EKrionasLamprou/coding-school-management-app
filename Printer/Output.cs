using System.Linq;
using System.Threading;
using static System.Console;

namespace Printer
{
    /// <summary>
    /// Contains methods for printing text on the console.
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// Outputs text to the console.
        /// </summary>
        /// <param name="text">The output string.</param>
        /// <param name="colours">The foreground and background colour pair.</param>
        /// <param name="delay">Milliseconds of delay before printing the text.</param>
        /// <param name="lineBreaks">Number of line breaks to follow the printed text.</param>
        public static void Print(string[] text, Colours colours = null,
            int lineBreaks = 1, int delay = 0) =>
            text.ToList()
                .ForEach(txt => Print(txt, colours, delay, lineBreaks));
        /// <summary>
        /// Outputs text to the console.
        /// </summary>
        /// <param name="text">The output string.</param>
        /// <param name="colours">The foreground and background colour pair.</param>
        /// <param name="delay">Milliseconds of delay before printing the text.</param>
        /// <param name="lineBreaks">Number of line breaks to follow the printed text.</param>
        public static void Print(string text = "", Colours colours = null,
            int lineBreaks = 1, int delay = 0)
        {
            Thread.Sleep(delay);
            ApplyColours(colours);
            Write(text);
            ResetColor();
            BreakLines(lineBreaks);
        }

        private static void ApplyColours(Colours colours)
        {
            if (colours is null) colours = new Colours();
            colours.Apply();
        }

        private static void BreakLines(int n)
        {
            for (int i = 0; i < n; i++)
            {
                WriteLine();
            }
        }
    }
}
