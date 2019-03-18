using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared
{
    public class Arrow
    {
        Node FromNode { get; set; }
        Pin FromPin { get; set; }

        List<Node> ToNodes { get; set; }
        List<Pin> ToPins { get; set; }

        public Arrow(Pin fromPin, Pin toPin)
        {
            FromPin = fromPin;
            ToPins = new List<Pin> { toPin };
        }

        public Arrow(Pin fromPin, List<Pin> toPins)
        {
            FromPin = fromPin;
            ToPins = toPins;
        }
    }
}
