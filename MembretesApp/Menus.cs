using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembretesApp
{
    internal class Menus
    {
        public static string? MenuOpciones()
        {
            Console.WriteLine("\n1. Escribir un membrete");
            Console.WriteLine("2. Cambiar el marco");
            Console.WriteLine("\n99. Salir");

            Console.Write("\n---->");

            return Console.ReadLine();
        }

        public static string? MenuFinal()
        {
            Console.WriteLine("\n1. Copiar diseño");
            Console.WriteLine("2. Exportar en txt");
            Console.WriteLine("3. Guardar como diseño para apliacion de consola");
            Console.WriteLine("\n99. Salir");

            Console.Write("\n---->");

            return Console.ReadLine();
        }
    }
}
