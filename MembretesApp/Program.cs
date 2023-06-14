using MembretesApp;
using Newtonsoft.Json;

string rutaArchivoJson = "json\\letters.json";

string json = File.ReadAllText(rutaArchivoJson);

lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);


var msg = Console.ReadLine();
string msg_codificado = "";

string[] lineas = { "", "", "", "", "" };



foreach (var letra in msg.ToUpper())
{
    try
    {
        var current = letterset.letters.FirstOrDefault(le => le.l == letra);
        for (int i = 0; i < 5; i++)
        {
            lineas[i] += current.lines[i];

        }
    }
    catch (Exception)
    {
        Console.WriteLine("xD");
    }
}

foreach (var linea in lineas)
{
    msg_codificado += linea + "\n";
}


Console.WriteLine(msg_codificado);

Console.Write("\nPresiona cualquier tecla para continuar...");
Console.ReadKey();
