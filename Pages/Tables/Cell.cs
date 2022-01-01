using Printer;

namespace Pages.Tables
{
    /// <summary>
    /// Represents a single cell of a table.
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// The text content of the cell.
        /// </summary>
        public string text;
        /// <summary>
        /// The number of characters the cell will hold.
        /// </summary>
        public int size;

        public Cell(string text, int size)
        {
            this.size = size;
            this.text = FormatText(text, size);
        }

        /// <summary>
        /// Prints the cell.
        /// </summary>
        /// <param name="colour">The foreground and background console colours</param>
        public void Print(Colours colour) => Output.Print(text, colour, 0);

        /// <summary>
        /// Aligns and formats the text to fit in the cell.
        /// </summary>
        private static string FormatText(string txt, int capacity) =>
            (txt.Length > capacity) ?
                txt.Substring(0, capacity) : // Shortens long strings.
                txt.PadRight(capacity);      // Aligns shorter strings.
    }
}
