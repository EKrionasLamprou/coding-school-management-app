using System;
using System.Collections.Generic;
using Printer;

namespace Pages
{
    /// <summary>
    /// Represents a menu list of options for the user to navigate.
    /// </summary>
    public class SelectList : Page
    {

        (int, int) cursorPosition;

        int selection = 0;
        /// <summary>
        /// The index of the current selected option.
        /// </summary>
        public int Selection
        {
            get => selection;
            set
            {
                if (value >= Options.Count) value = 0;
                else if (value < 0) value = Options.Count - 1;
                selection = value;
            }
        }
        /// <summary>
        /// Highlighted text that appears above the list.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Soft text that appears above the list.
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// The list's options
        /// </summary>
        public List<Option> Options { get; set; }
        /// <summary>
        /// The ESCAPE key's action.
        /// </summary>
        public Action EscapeAction { get; set; }

        public SelectList(string description, string info, List<Option> options, Action escapeAction)
        {
            Description = description;
            Info = info;
            Options = options;
            EscapeAction = escapeAction;
        }

        /// <summary>
        /// Prints the contents of the list on the console.
        /// </summary>
        public override void Render()
        {
            cursorPosition = (Console.CursorLeft, Console.CursorTop);
            PrintPageTop();
            
            for (int i = 0; i < Options.Count; i++)
            {
                bool isSelected = i == Selection;
                Options[i].Print(isSelected);
            }
            SelectOption();
        }

        private void PrintPageTop()
        {
            PrintDescription();
            PrintInfo();
        }
        private void PrintDescription() =>
            Output.Print(Description, new Colours(ConsoleColor.White, ConsoleColor.DarkBlue));
        private void PrintInfo() => Output.Print(Info, new Colours(ConsoleColor.DarkGray), 2);

        private void Rerender()
        {
            Console.SetCursorPosition(cursorPosition.Item1, cursorPosition.Item2);
            Render();
        }

        private void SelectOption()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    Selection++;
                    Rerender();
                    break;
                case ConsoleKey.UpArrow:
                    Selection--;
                    Rerender();
                    break;
                case ConsoleKey.Enter:
                    if(Options[Selection].Link != null)
                        Options[Selection].Select();
                    break;
                case ConsoleKey.Escape:
                    EscapeAction();
                    break;
                default:
                    SelectOption();
                    break;
            }
        }
    }
}
