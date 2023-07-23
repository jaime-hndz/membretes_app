using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembretesApp
{
    internal class Menus
    {
        public static string? OptionsMenu()
        {
            Console.WriteLine("\n1. Escribir un membrete");
            Console.WriteLine("2. Cambiar el marco");
            Console.WriteLine("\n99. Salir");

            Console.Write("\n---->");

            return Console.ReadLine();
        }
    }
}
