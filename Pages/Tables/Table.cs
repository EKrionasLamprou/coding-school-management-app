using System.Collections.Generic;
using System.Linq;
using Printer;

namespace Pages.Tables
{
    public class Table : Page
    {
        /// <summary>
        /// The table head, containing the column titles.
        /// </summary>
        public Row Head { get; set; }
        /// <summary>
        /// A list of the table's rows.
        /// </summary>
        public List<Row> Rows { get; } = new List<Row>();

        public Table(Dictionary<string, int> titles)
        {
            Head = new Row(titles.Keys.ToArray(), titles.Values.ToArray());
        }
        public Table(Row head)
        {
            Head = head;
        }

        /// <summary>
        /// Adds a new row to the Table.
        /// </summary>
        /// <param name="texts">The texts of the row's cells.</param>
        public void AddRow(string[] texts) => Rows.Add(new Row(texts, Head.Sizes));
        /// <summary>
        /// Adds a subrow to the last row of the table.
        /// </summary>
        /// <param name="texts">The texts of the extra row's cells.</param>
        public void AddSubrows(string[][] subRows)
        {
            Row lastRow = Rows.Last();
            lastRow.SubRows = subRows;
        }

        /// <summary>
        /// Prints the table's contents to the console.
        /// </summary>
        public override void Render()
        {
            if (Rows.Count > 0)
            {
                Head.Print();
                for (int i = 0; i < Rows.Count;)
                    Rows[i].Print(++i);
            }
            else
            {
                Output.Print("There are no items to show", new Colours(System.ConsoleColor.Gray));
            }

        }
    }
}
