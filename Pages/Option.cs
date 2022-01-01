using System;
using Printer;

namespace Pages
{
    public class Option
    {
        /// <summary>
        /// The option's description.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The action that gets invoked when the option is selected.
        /// </summary>
        public Action Link { get; set; }

        public Option(string text, Action link)
        {
            Text = text;
            Link = link;
        }

        /// <summary>
        /// Prints the option's text.
        /// </summary>
        /// <param name="isSelected">Highlights the option if it's selected.</param>
        public void Print(bool isSelected = false)
        {
            string text = $"< {Text} >";
            Colours colours = isSelected ?
                new Colours(ConsoleColor.Black, ConsoleColor.White) :
                new Colours();

            Output.Print(text, colours);
        }

        /// <summary>
        /// Invokes the option's action.
        /// </summary>
        public void Select() => Link();
    }
}
