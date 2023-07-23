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

    public static void GuardarMensajeEnArchivo(string mensaje)
    {
        string msg_to_file = "";

        foreach (var linea in mensaje.Split('\n'))
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

        TextCopy.ClipboardService.SetText(msg_to_file);

        using (StreamWriter sw = new StreamWriter("membrete.txt"))
        {
            sw.WriteLine(msg_to_file);
        }
    }
}

