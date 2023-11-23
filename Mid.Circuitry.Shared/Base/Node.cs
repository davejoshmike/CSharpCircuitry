using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public abstract class Node
    {
        #region Properties
        public int NodeId { get; private set; }
        public string Name { get; private set; }
        public List<Pin> Pins { get; private set; }
        public int ParentCircuitId { get; set; }
        #endregion Properties

        #region Constructor
        public Node(string name = "")
        {
            NodeId = UniqueIdGenerator.GenerateNodeId();
            Name = string.IsNullOrEmpty(name)
                ? $"{GetType().Name}{nameof(Node)}{NodeId}"
                : $"{name}{NodeId}";
            Pins = new List<Pin>();
            Off();
        }

        public Node(Pin pin, string name = "")
        {
            NodeId = UniqueIdGenerator.GenerateNodeId();
            Name = string.IsNullOrEmpty(name) 
                ? $"{GetType().Name}{nameof(Node)}{NodeId}" 
                : $"{name}{NodeId}";
            Pins = new List<Pin> { pin };
            Off();
        }

        public Node(List<Pin> pins, string name = "")
        {
            NodeId = UniqueIdGenerator.GenerateNodeId();
            Name = string.IsNullOrEmpty(name)
                ? $"{GetType().Name}{nameof(Node)}{NodeId}"
                : $"{name}{NodeId}";
            Pins = pins;
            Off();
        }
        #endregion

        #region Public Methods
        public abstract void InvokeAction(out bool passPower);

        /// <summary>
        /// Lookup the fromPinId from the Node's List of Pins 
        /// and add the route to the specified pin
        /// </summary>
        /// <param name="fromPinId"></param>
        /// <param name="toPinId"></param>
        public virtual void AddRoute(int fromPinId, int toPinId)
        {
            Pins.Single(pin => pin.PinId == fromPinId).ToPinId = toPinId;
        }

        public virtual void On()
        {
            foreach (Pin Pin in Pins)
            {
                Pin.On();
            }
        }

        public virtual void Off()
        {
            foreach (Pin Pin in Pins)
            {
                Pin.Off();
            }
        }

        public void UpsertPin(Pin pPin)
        {
            // TODO make this cleaner
            bool doesPinExist = Pins.Any(pin => pin.PinId == pPin.PinId);
            if (!doesPinExist)
            {
                Pins.Add(pPin);
            }
            else
            {
                Pins[Pins.FindIndex(pin => pin.PinId == pPin.PinId)] = pPin;
            }

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($@"  Node {NodeId}
    [
        Name: {Name}
        Pins: ");

            foreach(Pin pin in Pins)
            {
                builder.AppendLine(pin.ToString());
            }

            builder.AppendLine("    ]");
            return builder.ToString();
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
