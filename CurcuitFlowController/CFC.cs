using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mid.Circuitry.Shared;

namespace Mid.Circuitry.CircuitryFlowController
{
    public static class CFC
    {
        #region Properties
        /// <summary>
        /// Dictionary of Circuits (key: CircuitId)
        /// </summary>
        public static Dictionary<int, Circuit> CircuitTable { get; set; }

        /// <summary>
        /// Dictionary of Nodes in the circuit (key: NodeId)
        /// </summary>
        public static Dictionary<int, Node> NodeTable { get; set; }

        /// <summary>
        /// Dictionary of Pins to allow for node traversal (key: PinId)
        /// </summary>
        public static Dictionary<int, Pin> PinTable { get; set; }

        /// <summary>
        /// Dictionary of electricalFlow to allow for visualization of flow (key: ElectricalFlowId)
        /// </summary>
        public static Dictionary<int, ElectricalFlow> ElectricalFlowTable { get; set; }
        #endregion

        #region Init
        public static void Initialize()
        {
            CircuitTable = new Dictionary<int, Circuit>();

            NodeTable = new Dictionary<int, Node>();

            PinTable = new Dictionary<int, Pin>();

            //TODO Route ElectricalFlow and allow for electrical flow to be determined as broken or a complete circuit
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Populates the Circuit, Node and Pin tables
        /// </summary>
        /// <param name="circuit"></param>
        public static void RegisterCircuit(Circuit circuit)
        {
            CircuitTable.Add(circuit.CircuitId, circuit);
            foreach(Node node in circuit.Nodes)
            {
                NodeTable.Add(node.NodeId, node);
                foreach(Pin pin in node.Pins)
                {
                    PinTable.Add(pin.PinId, pin);
                }
            }
        }

        /// <summary>
        /// Recursively go through each Node of a circuit and call the Execute Action of each node
        /// </summary>
        /// <param name="startingNodeId"></param>
        /// <param name="previousPinId"></param>
        public static void StepThroughCircuit(int startingNodeId, int? previousPinId = null)
        {
            if (!CircuitTable.Any())
            {
                throw new Exception("CircuitTable not initialized");
            }

            Node fromNode = NodeTable[startingNodeId];
        
            // Call the node logic
            fromNode.InvokeAction(out bool passPower);

            var fromPins = fromNode.Pins.Where(x => x.PinId != previousPinId);

            foreach (Pin fromPin in fromPins)
            {
                if (fromPin.ToPinId.HasValue)
                {
                    int toPinId = fromPin.ToPinId.Value;

                    // TODO pass voltage through Nodes / through the InvokeActions???
                    // ElectricalFlowTable.Add(new ElectricalFlow(fromPin.PinId, toPinId, CalculateVoltage, CalculateAmps));

                    Pin toPin = PinTable[toPinId];

                    if (passPower)
                    {
                        toPin.On();
                    }

                    int toPinParentNodeId = toPin.ParentNodeId;

                    StepThroughCircuit(toPinParentNodeId, toPinId);
                }
            }
            // exit (no more nodes to traverse)
        }

        /// <summary>
        /// Clear all tables
        /// </summary>
        public static void ClearAllTables()
        {
            CircuitTable = new Dictionary<int, Circuit>();
            NodeTable = new Dictionary<int, Node>();
            PinTable = new Dictionary<int, Pin>();
        }
        #endregion

        #region Private Methods
        private static void UpsertIntoNodeTable(Node node)
        {
            if (NodeTable.ContainsKey(node.NodeId))
            {
                NodeTable[node.NodeId] = node;
            }
            else
            {
                NodeTable.Add(node.NodeId, node);
            }
        }
        #endregion
    }
}
