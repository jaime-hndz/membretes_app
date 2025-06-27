using MembretesApp;
using MembretesApp.entity;
using Newtonsoft.Json;

public class Functions
{

    public static string ObtenerMensaje(string mensaje)
    {
        try
        {
            string rutaArchivoJson = "json/letters.json";
            string json = File.ReadAllText(rutaArchivoJson);
            lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);

            string rutaArchivoJson2 = "json/frames.json";
            string json2 = File.ReadAllText(rutaArchivoJson2);
            framesSet? framesSet = JsonConvert.DeserializeObject<framesSet>(json2);

            frame fra = framesSet.frames.Where(f => f.index == "1").First();

            return CodificarMensaje(mensaje, letterset, fra);
        }
        catch (Exception e)
        {
            return e.Message;
        }

    }
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

    public static string ConvertirParaExportarConsola(string msg, int? type = 0)
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
            msg_to_file += type == 0 ? "Console.WriteLine(\"" + nuevaLinea + "\");\n" : "cout<<\"" + nuevaLinea + "\"<<endl;\n";
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

}

