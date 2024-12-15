using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticalTask
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LinearCongruentialGenerator lcg = new LinearCongruentialGenerator()
            {
                Seed = 7,
                Increment = 3,
                Modulus = 16,
                Multiplier = 5,
                N = 20
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(ref lcg));

            List<int> _out_  = lcg.LCG();

            Console.WriteLine("Generated Random Numbers:");
            foreach (int num in _out_)
            {
                Console.WriteLine(num);
            }

            int cycleLength = lcg.CalculateLenOfCycle();
            Console.WriteLine("Cycle Length" + cycleLength);
        }
    }
}
