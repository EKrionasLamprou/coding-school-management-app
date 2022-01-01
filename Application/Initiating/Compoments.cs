using System;
using System.Collections.Generic;
using static SCS.View.Menus.Navigator;
using Pages;


namespace SCS.Initiating
{
    static class Compoments
    {
        public static SelectList GetSelectList(string description, string info, MenuType returnMenu) =>
            new SelectList(description, info, new List<Option>(), GetMenuAction(returnMenu));

        public static void AddOption(SelectList list, string text, MenuType link) =>
            list.Options.Add(new Option(text, GetMenuAction(link)));

        public static Action GetMenuAction(MenuType target) => () => GoTo(target);
    }
}
