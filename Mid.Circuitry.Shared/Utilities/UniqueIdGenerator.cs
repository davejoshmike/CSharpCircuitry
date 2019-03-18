using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.Utilities
{
    public static class UniqueIdGenerator
    {
        private static int nodeId = 0;

        private static int pinId = 0;

        public static int GenerateNodeId()
        {
            nodeId++;
            return nodeId-1;
        }

        public static int GeneratePinId()
        {
            pinId++;
            return pinId - 1;
        }
    }
}
