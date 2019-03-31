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
