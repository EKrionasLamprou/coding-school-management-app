using System;
using System.Linq;
using Printer;

namespace Pages.Tables
{
    public class Row
    {
        /// <summary>
        /// An array of the row's cells.
        /// </summary>
        public Cell[] Cells { get; set; }
        /// <summary>
        /// The number of the row's cells.
        /// </summary>
        public int Length { get => Cells.Length; }
        /// <summary>
        /// An array that contains the size of each cell of the row.
        /// </summary>
        public int[] Sizes { get => Cells.Select(cell => cell.size).ToArray(); }
        public string[][] SubRows { get; set; }

        public Row(string[] texts, int[] sizes)
        {
            if (sizes.Length != texts.Length)
            {
                throw new Exception("The length of texts and sizes must be equal.");
            }

            Cells = new Cell[sizes.Length];
            for (int i = 0; i < sizes.Length; i++)
            {
                Cells[i] = new Cell(texts[i], sizes[i]);
            }
        }

        /// <summary>
        /// Prints all the cells of the row.
        /// </summary>
        /// <param name="type">The type of the row (head, odd or even).</param>
        public void Print(int? id = null)
        {
            Colours colours = GetRowColours(id);

            new Cell(id.ToString(), 4).Print(colours);
            foreach (var cell in Cells)
            {
                cell.Print(colours);
            }
            if (SubRows != null) PrintSubrows(colours);
            Output.Print();
        }

        /// <summary>
        /// Extends the last row with subrows.
        /// </summary>
        private void PrintSubrows(Colours colours)
        {
            foreach (string[] row in SubRows)
            {
                if (row == null) return;
                Output.Print();
                new Cell("", 4).Print(colours);
                for (int i = 0; i < Sizes.Length; i++)
                {
                    new Cell(row[i], Sizes[i]).Print(colours);
                }
            }
        }

        /// <summary>
        /// Returns the colour of the row, depending if the row is a table head, an odd or an even row.
        /// </summary>
        private Colours GetRowColours(int? id)
        {
            if (id is null)
                return new Colours(ConsoleColor.Black, ConsoleColor.White);
            else
            {
                return (id % 2 == 0) ?
                    new Colours(ConsoleColor.White, ConsoleColor.DarkGray) :
                    new Colours(ConsoleColor.White, ConsoleColor.Black);
            }
        }
    }
}
