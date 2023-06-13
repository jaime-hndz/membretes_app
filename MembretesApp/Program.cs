using MembretesApp;
using Newtonsoft.Json;

string rutaArchivoJson = "D:\\Apps\\MembretesApp\\MembretesApp\\json\\letters.json";

string json = File.ReadAllText(rutaArchivoJson);

lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);


var msg = Console.ReadLine();
string msg_codificado = "";

string linea1 = "";
string linea2 = "";
string linea3 = "";
string linea4 = "";
string linea5 = "";



foreach (var letra in msg.ToUpper())
{
    try
    {
        var current = letterset.letters.FirstOrDefault(le => le.l == letra);
        linea1 += current.l1;
        linea2 += current.l2;
        linea3 += current.l3;
        linea4 += current.l4;
        linea5 += current.l5;

    }
    catch (Exception)
    {

        Console.WriteLine("xD");
    }
}

msg_codificado += linea1 + "\n";
msg_codificado += linea2 + "\n";
msg_codificado += linea3 + "\n";
msg_codificado += linea4 + "\n";
msg_codificado += linea5 + "\n";

Console.WriteLine(msg_codificado);

Console.Write("\nPresiona cualquier tecla para continuar...");
Console.ReadKey();
