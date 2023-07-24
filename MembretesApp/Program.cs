using MembretesApp;

string? opt = "0";

while(opt != "99")
{
    Console.Clear();


    opt = Menus.OptionsMenu();

    switch (opt)
    {
        case "1":
            Screens.MembreteScreen();
            break;
        case "2":
            Screens.FramesScreen();
            break;
        default:
            break;
    }

}