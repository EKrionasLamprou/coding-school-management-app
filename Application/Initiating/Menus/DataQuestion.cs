using Pages;
using static SCS.Initiating.Compoments;

namespace SCS.Initiating.Menus
{
    class DataQuestion
    {
        public bool Begin()
        {
            string description = "Press enter to select an option,.";
            string info = "Use the up and down arrow keys to navigate.";
            SelectList list = GetSelectList(description, info, MenuType.Exit);

            list.Options.Add(new Option("Load data", null));
            list.Options.Add(new Option("Start empty project", null));

            list.Render();

            return list.Selection == 0;
        }
    }
}
