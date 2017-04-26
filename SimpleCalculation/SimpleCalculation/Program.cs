using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            string monPrenom;
            double nombre1, nombre2;

            Console.Write("Entrez votre prénom: ");
            monPrenom = Console.ReadLine();
            Console.WriteLine($"Bonjour, {monPrenom}");

            Console.Write("Entrez premier nombre: ");
            nombre1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entrez deuxième nombre: ");
            nombre2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"{nombre1} + {nombre2} = " + $"{nombre1 + nombre2}");
            Console.WriteLine($"{nombre1} - {nombre2} = " + $"{nombre1 - nombre2}");
            Console.WriteLine($"{nombre1} * {nombre2} = " + $"{nombre1 * nombre2}");
            Console.WriteLine($"{nombre1} / {nombre2} = " + $"{nombre1 / nombre2}");
            Console.WriteLine($"{nombre1} % {nombre2} = " + $"{nombre1 % nombre2}");

            Console.ReadKey();
        }
    }
}

