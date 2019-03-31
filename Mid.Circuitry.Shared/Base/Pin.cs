using System;
using System.Collections.Generic;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public class Pin
    {
        #region Properties
        public int PinId { get; private set; }
        public string Name { get; set; }
        public StateEnum State { get; private set; }
        public PolarityEnum Polarity { get; set; }

        public int ParentNodeId { get; set; }
        public int? ToPinId { get; set; }
        #endregion

        #region Constructor
        public Pin(int parentNodeId, StateEnum state = StateEnum.OFF, PolarityEnum polarity = PolarityEnum.POS, string name = "")
        {
            PinId = UniqueIdGenerator.GeneratePinId();
            Name = string.IsNullOrEmpty(name)
                ? $"{GetType().Name}{nameof(Pin)}{PinId}"
                : $"{name}{PinId}";
            State = state;
            Polarity = polarity;

            ParentNodeId = parentNodeId;
        }

        /// <summary>
        /// Constructor for adding a route and adding the ToPinId
        /// </summary>
        /// <param name="fromPinId"></param>
        /// <param name="toPinId"></param>
        /// <param name="state"></param>
        /// <param name="polarity"></param>
        /// <param name="name"></param>
        public Pin(int fromPinId, int toPinId, int parentNodeId, StateEnum state = StateEnum.OFF, PolarityEnum polarity = PolarityEnum.POS, string name = "")
        {
            PinId = fromPinId;
            Name = string.IsNullOrEmpty(name) 
                ? $"{GetType().Name}{nameof(Pin)}{PinId}" 
                : $"{name}{PinId}";
            State = state;
            Polarity = polarity;
            ParentNodeId = parentNodeId;
        }
        #endregion

        #region Public Methods
        public void UpdateToToPin(int pinId)
        {
            PinId = pinId;
        }

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

        public override string ToString()
        {
            return $@"      Pin {PinId}
        [
            Name: {Name} 
            State: {State}
            Polarity: {Polarity}
        ]";
        }
        #endregion

        #region Private Methods
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
