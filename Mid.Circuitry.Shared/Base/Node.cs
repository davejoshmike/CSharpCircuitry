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
        public int Id { get; private set; }
        public string Name { get; private set; }

        public List<Pin> Pins { get; set; }
        #endregion Properties

        #region Constructor
        public Node(string callingClass = nameof(GetType))
        {
            Id = UniqueIdGenerator.GenerateNodeId();
            Name = callingClass;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Lookup the fromPinId from the Node's List of Pins 
        /// and add the route to the specified pin
        /// </summary>
        /// <param name="fromPinId"></param>
        /// <param name="toPinId"></param>
        public void AddRoute(int fromPinId, int toPinId)
        {
            Pins.First(pin => pin.PinId == fromPinId).ToPinId = toPinId;
        }
        #endregion
    }
}
