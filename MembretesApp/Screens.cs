using MembretesApp.entity;
using Newtonsoft.Json;

namespace MembretesApp
{
    public class Screens
    {
        public static void MembreteScreen()
        {
            Console.Clear();
            string rutaArchivoJson = "json\\letters.json";
            string json = File.ReadAllText(rutaArchivoJson);
            lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);

            string rutaArchivoJson2 = "json\\frames.json";
            string json2 = File.ReadAllText(rutaArchivoJson2);
            framesSet? framesSet = JsonConvert.DeserializeObject<framesSet>(json2);

            frame fra = framesSet.frames.First();

            Console.WriteLine("Ingresa un mensaje:");
            var msg = Console.ReadLine();
            string msg_codificado = Functions.CodificarMensaje(msg, letterset, fra);

            Console.WriteLine(msg_codificado);

            Functions.SetEndMenu(msg_codificado);


            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    
    }
}
