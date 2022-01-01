using static SCS.View.Menus.Collection;

namespace SCS.View.Menus
{
    /// <summary>
    /// Navigates to the different menus.
    /// </summary>
    static class Navigator
    {
        /// <summary>
        /// Shows a menu, based on menu type.
        /// </summary>
        /// <param name="menu">The menu type.</param>
        public static void GoTo(MenuType menu)
        {
            if (menu == MenuType.Exit) System.Environment.Exit(0);
            list[menu].Show();
        }
    }
}
