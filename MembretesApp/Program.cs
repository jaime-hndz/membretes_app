using MembretesApp.entity;
using Newtonsoft.Json;

string rutaArchivoJson = "json\\letters.json";

string json = File.ReadAllText(rutaArchivoJson);

lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);


string rutaArchivoJson2 = "json\\frames.json";

string json2 = File.ReadAllText(rutaArchivoJson2);

framesSet? framesSet = JsonConvert.DeserializeObject<framesSet>(json2);

frame fra = framesSet.frames.First();

var msg = Console.ReadLine();
string msg_codificado = "";

string[] lineas = { "", "", "", "", "", "", "" };



foreach (var letra in msg.ToUpper())
{
    try
    {
        var current = letterset.letters.FirstOrDefault(le => le.l == letra);
        for (int i = 0; i < 5; i++)
        {
            lineas[i+1] += current.lines[i];

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
    lineas[0] += fra.borderX;
    lineas[6] += fra.borderX;
}

for(int i = 0; i < lineas.Length; i++)
{
    if (i == 0 || i == 6)
    {
        lineas[i] = fra.corner + fra.borderX + lineas[i] + fra.borderX + fra.corner + "\n";
    }
    else
    {
        lineas[i] = fra.borderY + " " + lineas[i] + " " + fra.borderY + "\n";
    }
    
}

foreach (var linea in lineas)
{
    msg_codificado += linea;
}


Console.WriteLine(msg_codificado);

Console.Write("\nPresiona cualquier tecla para continuar...");
Console.ReadKey();
