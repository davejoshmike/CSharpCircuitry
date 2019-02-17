using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Mid.Circuitry.CircuitryFlowController;

namespace Mid.Circuitry.CircuitryRunner
{
    public class CircuitryRunner
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">> Starting up...");

            Initialize();

            print_line("Hehllo Verld");

            Console.WriteLine("<< Exit.");
        }


        [DllImport("NativeLib.dll")]
        private static extern void print_line(string str);

        private static void Initialize()
        {
            Console.WriteLine("Initializing Circuitry Runner...");

            CFC.Initialize();

            Console.WriteLine("Circuitry Runner Initialized.");
        }
    }
}
