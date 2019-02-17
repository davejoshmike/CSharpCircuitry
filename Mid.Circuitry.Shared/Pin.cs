using System;
using System.Collections.Generic;

namespace Mid.Circuitry.Shared
{
    public class Pin
    {
        public IOEnum IO { get; set; }
        public StateEnum State { get; private set; }
        public PolarityEnum Polarity { get; set; }

        public Pin()
        {
            IO = IOEnum.IN;
            Polarity = PolarityEnum.POS;
            State = StateEnum.ON;
        }

        public Pin(IOEnum io, StateEnum state)
        {
            IO = io;
            State = state;

            Polarity = IO.Equals(IOEnum.IN) 
                ? PolarityEnum.POS 
                : PolarityEnum.NEG;
        }

        public void TurnOn()
        {
            State = StateEnum.ON;
        }
        public void TurnOff()
        {
            State = StateEnum.OFF;
        }
    }

    public enum IOEnum
    {
        OUT, // Negative
        IN // Positive
    }

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
}
