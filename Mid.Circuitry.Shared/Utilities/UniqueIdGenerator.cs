using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.Utilities
{
    public static class UniqueIdGenerator
    {
        private static int circuitId = 1;

        private static int nodeId = 1;

        private static int pinId = 1;

        private static int electricalFlowId = 1;

        public static int GenerateCircuitId()
        {
            circuitId++;
            return circuitId - 1;
        }

        public static int GenerateNodeId()
        {
            nodeId++;
            return nodeId - 1;
        }

        public static int GeneratePinId()
        {
            pinId++;
            return pinId - 1;
        }

        public static int GenerateElectricalFlowId()
        {
            electricalFlowId++;
            return electricalFlowId - 1;
        }
    }
}
