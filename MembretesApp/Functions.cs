using MembretesApp;
using MembretesApp.entity;

public class Functions
{
    public static string CodificarMensaje(string mensaje, lettersSet? letterset, frame frame)
    {
        string[] lineas = { "", "", "", "", "", "", "" };

        for (int a = 0; a < mensaje.Length; a++)
        {
            var letra = mensaje.ToUpper()[a];
            try
            {
                var current = letterset.letters.FirstOrDefault(le => le.l == letra);
                for (int i = 0; i < 5; i++)
                {
                    lineas[i + 1] += current.lines[i];
                }
            }
            catch (Exception)
            {
                Console.WriteLine("xD");
            }
        }

        int size = 0;
        size = lineas[1].Length;

        for (int i = 0; i < size; i++)
        {
            lineas[0] += frame.borderX;
            lineas[6] += frame.borderX;
        }

        for (int i = 0; i < lineas.Length; i++)
        {
            if (i == 0 || i == 6)
            {
                lineas[i] = frame.corner + frame.borderX + lineas[i] + frame.borderX + frame.corner;
            }
            else
            {
                lineas[i] = frame.borderY + " " + lineas[i] + " " + frame.borderY;
            }
        }

        string msg_codificado = string.Join("\n", lineas);
        return msg_codificado;
    }

    public static void CopiarMensaje(string msg)
    {
        TextCopy.ClipboardService.SetText(msg);

    }

    public static string ConvertirParaExportarConsola(string msg)
    {
        string msg_to_file = "";

        foreach (var linea in msg.Split('\n'))
        {
            string nuevaLinea = string.Empty;
            foreach (var letra in linea)
            {
                if (letra == '\\')
                {
                    nuevaLinea += letra.ToString() + letra.ToString();
                }
                else
                {
                    nuevaLinea += letra.ToString();
                }
            }
            msg_to_file += "cout<<\"" + nuevaLinea + "\"<<endl;\n";
        }
        return msg_to_file;
    }

    public static void GuardarMensajeEnArchivo(string mensaje)
    {



        using (StreamWriter sw = new StreamWriter("membrete.txt"))
        {
            sw.WriteLine(mensaje);
        }
    }

    public static void SetEndMenu(string msg)
    {
        string? opt = "0";

        while (opt != "99") {
            opt = Menus.EndMenu();

            switch (opt)
            {
                case "1":
                    Functions.CopiarMensaje(msg);
                    Console.WriteLine("mensaje copiado!");
                    break;
                case "2":
                    Functions.GuardarMensajeEnArchivo(msg);
                    Console.WriteLine("mensaje guardado en membrete.txt!");
                    break;
                case "3":
                    msg = ConvertirParaExportarConsola(msg);
                    Console.WriteLine("mensaje convertido para consola!");
                    break;
                default:
                    break;
            }

        }
    }
}

