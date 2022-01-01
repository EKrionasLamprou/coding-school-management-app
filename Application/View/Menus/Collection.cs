using System.Collections.Generic;

namespace SCS.View.Menus
{
    /// <summary>
    /// Stores a list in the form of a dictionary, that directs to each menu, by menu type.
    /// </summary>
    static class Collection
    {
        /// <summary>
        /// A dictionary that directs to each menu object by menu type.
        /// </summary>
        public static Dictionary<MenuType, Menu> list = new Dictionary<MenuType, Menu>();
    }
}
