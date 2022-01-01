using System;
using static SCS.Initiating.Compoments;
using SCS.View.Menus;
using Pages;
using Printer;

namespace SCS.Initiating.Menus
{
    class TableMenu : IInitiating
    {
        Action tableShow;
        MenuType menu;
        string title;
        string entity1, entity2;

        public TableMenu(Action tableShow, MenuType menu, string title, string entity1, string entity2 = null)
        {
            this.tableShow = tableShow;
            this.menu = menu;
            this.title = title;
            (this.entity1, this.entity2) = (entity1, entity2);
        }

        public void Initiate()
        {
            Action show;
            SelectList list = GetTableSelectList();

            show = () =>
            {
                tableShow();
                Output.Print(lineBreaks: 2);
                list.Render();
            };

            Collection.list[menu] = new Menu(show, title);
        }

        private SelectList GetTableSelectList()
        {
            string description = "Press enter to select an option, or escape to exit.";
            string info = "Use the up and down arrow keys to navigate.";
            SelectList list = GetSelectList(description, info, MenuType.Home);
            if (entity2 is null)
            {
                AddOption(list, $"Add {entity1}", menu + 1);
                AddOption(list, $"Edit {entity1}", menu + 2);
                AddOption(list, $"Remove {entity1}", menu + 3);
            }
            else
            {
                AddOption(list, $"Add {entity1} to {entity2}", menu + 1);
                AddOption(list, $"Remove {entity1} from {entity2}", menu + 2);
            }

            return list;
        }
    }
}
