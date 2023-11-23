using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Mid.Circuitry.Shared;
using Mid.Circuitry.CircuitryFlowController;

namespace Mid.Circuitry.CircuitryRunner
{
    public class CircuitryRunner
    {
        #region Constants

        private const string inputPrompt = @"Please choose an option:
n - go to next node
p - go to previous node
a - add node
r - remove current node
v - view circuit
x - exit";

        #endregion

        #region Fields

        #endregion

        public static void Main(string[] args)
        {
            Console.WriteLine(">> Starting up...");

            initialize();

            //pinvoke stuff
            //print_line("Hello World");

            string consoleInput = String.Empty;
            bool shouldExit = false;
            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine(inputPrompt);
                consoleInput = Console.ReadLine();
                checkInput(consoleInput, out shouldExit);
            }
            
            Console.WriteLine("<< Exit.");
        }

        private static void checkInput(string consoleInput, out bool shouldExit)
        {
            shouldExit = false;

            switch (consoleInput)
            {
                case "n":
                    moveToNextNodeCommand();
                    break;
                case "p":
                    moveToPreviousNodeCommand();
                    break;
                case "a":
                    addCommand();
                    break;
                case "r":
                    removeCommand();
                    break;
                case "v":
                    viewCircuitCommand();
                    break;
                case "x":
                    shouldExit = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid command.");
                    break;
            }
        }

        private static void moveToNextNodeCommand()
        {
            Console.WriteLine("n command not current implemented.");
        }

        private static void moveToPreviousNodeCommand()
        {
            Console.WriteLine("p command not current implemented.");
        }

        private static void addCommand()
        {
            Console.WriteLine("a command not current implemented.");
        }

        private static void removeCommand()
        {
            Console.WriteLine("r command not current implemented.");
        }

        private static void viewCircuitCommand()
        {
            Console.WriteLine("c command not current implemented.");
        }

        // pinvoke stuff
        //[DllImport("NativeLib.dll")]
        //private static extern void print_line(string str);

        private static void initialize()
        {
            Console.WriteLine("Initializing Circuitry Runner...");

            CFC.Initialize();

            Console.WriteLine("Circuitry Runner Initialized.");
        }
    }
}
