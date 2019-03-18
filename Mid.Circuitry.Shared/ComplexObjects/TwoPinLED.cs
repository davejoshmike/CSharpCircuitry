using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.ComplexObjects
{
    /// <summary>
    /// Default LED type is three pin
    /// Possible Types:
    /// Three Pin
    /// RGB
    /// </summary>
    public class TwoPinLED : Node
    {

        #region Fields
        public Pin Anode { get; set; }
        public Pin Cathode { get; set; }        
        #endregion

        #region Constructor
        public TwoPinLED() : base()
        {
            Anode = new Pin();
            //PosPin.IO = IOEnum.IN;
            Anode.Polarity = PolarityEnum.POS;
            Anode.On();

            Cathode = new Pin();
            //NegPin.IO = IOEnum.OUT;
            Cathode.Polarity = PolarityEnum.NEG;
            Cathode.Off();
        }

        #endregion Constructor

    }
}
