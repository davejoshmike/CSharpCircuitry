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
        public PowerTypeEnum PowerType { get; set; }
        public Pin PowerPin
        {
            get => Pins.First(pin => pin.Name.StartsWith(nameof(PowerPin)));
            set
            {
                value.Name = $"{nameof(PowerPin)}{value.PinId}";
                UpsertPin(value);
            }
        }
        #endregion

        #region Constructor
        public PowerSource(PowerTypeEnum powerType = PowerTypeEnum.PT3V3) : base()
        {
            PowerType = powerType;
            Pins.Add(new Pin(NodeId, name: nameof(PowerPin), polarity: PowerType == PowerTypeEnum.GND ? PolarityEnum.NEG : PolarityEnum.POS));
        }
        #endregion

        #region Public Methods
        public override void ExecuteAction(out bool passPower)
        {
            passPower = false;
            Console.WriteLine($">> ExecuteAction for {Name}");

            if (PowerPin.State == StateEnum.ON)
            {
                passPower = true;
                Console.WriteLine("Passing power to next Node.");
            }

            Console.WriteLine($"<< ExecuteAction for {Name}");
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
