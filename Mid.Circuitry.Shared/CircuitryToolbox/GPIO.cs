using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared;

namespace Mid.Circuitry.Shared.CircuitryToolbox
{
    public class Gpio : Node
    {
        #region Properties
        public IOEnum IO { get; set; }

        public Pin GpioPin
        {
            get => Pins.First();
            set
            {
                value.Name = $"{nameof(GpioPin)}{value.PinId}";
                UpsertPin(value);
            }
        }
        public int GpioPinNumber { get; private set; }
        #endregion

        #region Constructor
        public Gpio(int gpioPinNumber) : base()
        {
            GpioPinNumber = gpioPinNumber;
            Pins.Add(new Pin(NodeId, StateEnum.ON, PolarityEnum.NEG, $"{nameof(GpioPin)}"));
            IO = IOEnum.OUT;
        }
        #endregion

        #region Public Methods
        public override void InvokeAction(out bool passPower)
        {
            passPower = false;
            Console.WriteLine($"> InvokeAction for {Name}");
            
            if (GpioPin.State == StateEnum.ON)
            {
                passPower = true;
                Console.WriteLine("Passing power to next Node.");
            }

            Console.WriteLine($"< InvokeAction for {Name}");
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
