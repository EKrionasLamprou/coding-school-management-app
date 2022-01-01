using SCS.Initiating.Menus;
using SCS.View.Menus;

namespace SCS
{
    class Application
    {
        static void Main()
        {
            new Initiating.Initiator().InitiateAll();

            if(new DataQuestion().Begin())
                new SyntheticData().Load();

            Navigator.GoTo(MenuType.Home);
        }
    }
}
