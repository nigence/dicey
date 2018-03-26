using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ld;

namespace ld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liar's dice game development...");

            permutationsCalculator pc = new permutationsCalculator();

            Console.WriteLine( pc.getPermutationTable());

            //unitTester ut = new unitTester();
            //ut.runAll();


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
