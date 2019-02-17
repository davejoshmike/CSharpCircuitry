using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mid.Circuitry.CircuitryFlowController.Shared;

namespace Mid.Circuitry.CircuitryFlowController
{
    public static class CFC
    {
        public static void Initialize()
        {
            Console.WriteLine("Initializing Circuitry Flow Controller...");

            // Do any necessary init actions

            Console.WriteLine("Circuitry Flow Controller Initialized.");
        }

        public static List<Arrow> FlowArrows { get; set; }

        public static List<Node> FlowNodes { get; set; }

        public static Circuit Circuit { get; set; }
    }
}
