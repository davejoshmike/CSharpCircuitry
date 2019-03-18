using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.CircuitryToolbox
{
    public class PowerSource : Node
    {
        #region Fields
        public Pin Pin { get; set; }
        public PowerTypeEnum PowerType { get; set; }
        #endregion

        #region Constructor
        public PowerSource(PowerTypeEnum powerType = PowerTypeEnum.PT3V3) : base()
        {
            PowerType = powerType;
            Pin Pin = new Pin(polarity: PowerType == PowerTypeEnum.GND ? PolarityEnum.NEG : PolarityEnum.POS);
        }
        #endregion

        #region Enums
        public enum PowerTypeEnum
        {
            PT3V3,
            PT5V,
            GND
        }
        #endregion Enums
    }
}
