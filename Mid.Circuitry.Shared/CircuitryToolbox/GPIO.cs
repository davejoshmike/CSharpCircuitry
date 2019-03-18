using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared;

namespace Mid.Circuitry.Shared.CircuitryToolbox
{
    public class GPIO : Node
    {
        #region Properties
        public IOEnum IO { get; set; }

        public Pin Pin { get; private set; }

        public int PinNumber { get; private set; }
        #endregion

        #region Constructor
        public GPIO(int pinNumber) : base()
        {
            PinNumber = pinNumber;
            Pin Pin = new Pin(StateEnum.ON, PolarityEnum.NEG);
            IO = IOEnum.OUT;
        }
        #endregion
    }

    #region Enums
    public enum IOEnum
    {
        OUT,
        IN
    }
    #endregion
}
