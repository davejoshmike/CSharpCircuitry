using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared;
using Mid.Circuitry.Shared.CircuitryToolbox;

namespace Mid.Circuitry.CircuitryFlowController
{
    public class Circuit
    {
        #region Fields
        List<object> Segments;

        Transistor Transistors;

        Pin GND;

        #endregion

        public Circuit()
        {

        }

        public override string ToString()
        {
            //TODO make cool Circuitry diagram output
            return base.ToString();
        }
    }
}
