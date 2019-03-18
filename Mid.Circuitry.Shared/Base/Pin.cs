using System;
using System.Collections.Generic;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public class Pin
    {
        #region Properties
        public int PinId { get; private set; }
        public string Name { get; private set; }
        public StateEnum State { get; private set; }
        public PolarityEnum Polarity { get; set; }

        public int ParentNodeId { get; set; }
        public int? ToPinId { get; set; }
        #endregion

        #region Constructor
        public Pin(StateEnum state = StateEnum.OFF, PolarityEnum polarity = PolarityEnum.POS, string callingClass = nameof(GetType))
        {
            // TODO have the Polarity validated / determined later by the CFC
            PinId = UniqueIdGenerator.GeneratePinId();
            Name = callingClass;

            State = state;
            Polarity = polarity;
        }
        #endregion
           
        #region Public Methods
        public void On()
        {
            State = StateEnum.ON;
        }

        public void Off()
        {
            State = StateEnum.OFF;
        }

        public string PinStringFormat()
        {
            return $"{Name}{PinId}";
        }
        #endregion
    }

    #region Enums
    public enum PolarityEnum
    {
        NEG, // Negative
        POS // Positive
    }

    public enum StateEnum
    {
        OFF, // LOW
        ON // HIGH
    }
    #endregion
}
