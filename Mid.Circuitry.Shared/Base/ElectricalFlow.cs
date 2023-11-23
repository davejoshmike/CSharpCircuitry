using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public class ElectricalFlow
    {
        #region Fields
        public int ElectricalFlowId { get; private set; }

        public int FromPinId { get; set; }
        public int ToPinId { get; set; }

        public double Voltage { get; set; }
        public double Amps { get; set; }
        #endregion

        #region Constructor
        public ElectricalFlow(int fromPinId, int toPinId, double voltage, double amps)
        {
            ElectricalFlowId = UniqueIdGenerator.GenerateElectricalFlowId();
            FromPinId = fromPinId;
            ToPinId = toPinId;

            Voltage = voltage;
            Amps = amps;
        }
        #endregion
    }
}
