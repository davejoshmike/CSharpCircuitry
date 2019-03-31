using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public class Arrow
    {
        #region Fields
        public int ArrowId { get; private set; }

        public int FromPinId { get; set; }
        public int ToPinId { get; set; }

        public double Voltage { get; set; }
        public double Amps { get; set; }
        #endregion

        #region Constructor
        public Arrow(int fromPinId, int toPinId, double voltage, double amps)
        {
            ArrowId = UniqueIdGenerator.GenerateArrowId();
            FromPinId = fromPinId;
            ToPinId = toPinId;

            Voltage = voltage;
            Amps = amps;
        }
        #endregion
    }
}
