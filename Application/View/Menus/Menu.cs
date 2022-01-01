using System;
using Printer;

namespace SCS.View.Menus
{
    /// <summary>
    /// Represents a menu that outputs on the console.
    /// </summary>
    class Menu
    {
        /// <summary>
        /// An action that get's invoked on menu show.
        /// </summary>
        public Action Action { get; set; }
        /// <summary>
        /// The title of the menu.
        /// </summary>
        public string Title { get; set; }

        public Menu(Action action, string title = null)
        {
            Action = action;
            Title = title;
        }

        /// <summary>
        /// Renders the header, the title and invokes the menu action.
        /// </summary>
        public void Show()
        {
            Header.Render();
            if (Title != null) PrintTitle();
            Action();
        }

        /// <summary>
        /// Prints the title of the menu to the console.
        /// </summary>
        private void PrintTitle() => Output.Print(Title.ToUpper(), lineBreaks: 2);
    }
}
