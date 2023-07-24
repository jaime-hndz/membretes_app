using MembretesApp;

string? opt = "0";

while(opt != "99")
{
    Screens.MembreteTitulo();

    opt = Menus.MenuOpciones();

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