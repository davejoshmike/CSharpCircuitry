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
        public Pin Anode
        {
            get => base.Pins.First(pin => pin.Name.StartsWith(nameof(Anode)));
            set
            {
                value.Name = $"{nameof(Anode)}{value.PinId}";
                base.UpsertPin(value);
            }
        }

        public Pin Cathode
        {
            get => base.Pins.First(pin => pin.Name.StartsWith(nameof(Cathode)));
            set
            {
                value.Name = $"{nameof(Cathode)}{value.PinId}";
                base.UpsertPin(value);
            }
        }
        #endregion

        #region Constructor
        public TwoPinLED() : base()
        {
            Anode = new Pin(NodeId);
            //Anode.IO = IOEnum.IN;
            Anode.Polarity = PolarityEnum.POS;

            Cathode = new Pin(NodeId);
            //Cathode.IO = IOEnum.OUT;
            Cathode.Polarity = PolarityEnum.NEG;
        }
        #endregion Constructor

        #region Public Methods
        public override void InvokeAction(out bool passPower)
        {
            passPower = false;
            Console.WriteLine($"> InvokeAction for {Name}");

            if(Anode.State == StateEnum.ON)
            {
                Cathode.On();
                passPower = true;
                Console.WriteLine("Turned Cathode on. Passing Power to next Node.");
            }

            Console.WriteLine($"< InvokeAction for {Name}");
        }
        #endregion
    }
}
