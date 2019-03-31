using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared.CircuitryToolbox
{
    public class Button : Node
    {
        public Button() : base()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteAction(out bool passPower)
        {
            passPower = false;
            Console.WriteLine($">> ExecuteAction for {Name}");

            //TODO Add logic here

            Console.WriteLine($"<< ExecuteAction for {Name}");

            throw new NotImplementedException();
        }
    }
}
