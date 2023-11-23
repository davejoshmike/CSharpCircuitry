using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.ComplexObjects
{
    public class Buzzer : Node
    {
        public Buzzer() : base()
        {
            throw new NotImplementedException();
        }

        public override void InvokeAction(out bool passPower)
        {
            passPower = false;
            Console.WriteLine($"> InvokeAction for {Name}");

            //TODO Add logic here

            Console.WriteLine($"< InvokeAction for {Name}");

            throw new NotImplementedException();
        }
    }
}
