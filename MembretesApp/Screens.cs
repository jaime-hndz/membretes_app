using MembretesApp.entity;
using Newtonsoft.Json;

namespace MembretesApp
{
    public class Screens
    {
        private static string _frameIndex = "1";
        public static void MembreteScreen()
        {
            Console.Clear();
            string rutaArchivoJson = "json\\letters.json";
            string json = File.ReadAllText(rutaArchivoJson);
            lettersSet? letterset = JsonConvert.DeserializeObject<lettersSet>(json);

            string rutaArchivoJson2 = "json\\frames.json";
            string json2 = File.ReadAllText(rutaArchivoJson2);
            framesSet? framesSet = JsonConvert.DeserializeObject<framesSet>(json2);

            frame fra = framesSet.frames.Where(f => f.index == _frameIndex).First();

            Console.WriteLine("Ingresa un mensaje:");
            var msg = Console.ReadLine();
            string msg_codificado = Functions.CodificarMensaje(msg, letterset, fra);

            Console.WriteLine(msg_codificado);

            Functions.SetEndMenu(msg_codificado);


            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void FramesScreen()
        {

            string rutaArchivoJson2 = "json\\frames.json";
            string json2 = File.ReadAllText(rutaArchivoJson2);
            framesSet? framesSet = JsonConvert.DeserializeObject<framesSet>(json2);


            do
            {
                Console.Clear();
                foreach (var frame in framesSet.frames)
                {
                    string l1, l2;

                    l1 = frame.corner;
                    l2 = frame.borderY;
                    for (int i = 0; i < frame.name.Length; i++)
                    {
                        l1 += frame.borderX;

                    }
                    l2 += frame.name.ToUpper();
                    l1 += frame.corner;
                    l2 += frame.borderY;

                    Console.WriteLine(frame.index + ": \n" + l1 + "\n" + l2 + "\n" + l1);



                }
                Console.Write("\n---->");

                _frameIndex = Console.ReadLine();


                Console.Write("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();

            } while(framesSet.frames.Where(f => f.index == _frameIndex).Count() <= 0);

        }


    }
}
