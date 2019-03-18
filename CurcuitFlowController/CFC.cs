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
        public static void Initialize()
        {
            Console.WriteLine("Initializing Circuitry Flow Controller...");

            NodeTable = new Dictionary<int, Node>();

            PinTable = new Dictionary<int, Pin>();

            Console.WriteLine("Circuitry Flow Controller Initialized.");
        }

        /// <summary>
        /// Dictionary of Nodes in the circuit (key: NodeId)
        /// </summary>
        public static Dictionary<int, Node> NodeTable { get; set; }

        /// <summary>
        /// Dictionary of Pins to allow for quicker node traversal (key: PinId)
        /// </summary>
        public static Dictionary<int, Pin> PinTable { get; set; }

        #region Public Methods
        public static void ConnectPin(Node fromNode, int fromPinId, int toPinId)
        {

            //every single node has a list of toPins
            // but also needs an idea of which pin it has links to another pin
            // therefore, the pin class needs a topin property, rather than containing it in the node
            // but the pin also needs to know which node it belongs to
            fromNode.Pins.Single(pin => pin.PinId == fromPinId).ToPinId = toPinId;
            AddOrOverwriteNode(fromNode);
        }

        /// <summary>
        /// Lookup in Node table where toPin.parentNodeId == node.Id 
        /// and traverse that way through the nodes
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public static Node LookupNode(int nodeId)
        {
            return NodeTable[nodeId];
        }

        //TODO add a method for Node Traversal (Each node has pins which have ToPinIds)
        // REVISE ALGORITHM
        // Need to go through each path (recursive)
        // Might have more than one pin to go to next?

        // This assumes that the PinTable works and has every single pin
        public static void StepThroughCircuitWithPins(int fromPinId)
        {
            if(!PinTable.Any())
            {
                PopulatePinTable();
            }

            // Lookup PinTable
            Pin fromPin = PinTable[fromPinId];
            if (fromPin.ToPinId.HasValue)
            {
                int toPinId = fromPin.ToPinId.Value;

                StepThroughCircuitWithPins(toPinId);
            }
            // exit (no more pins to traverse)            
        }

        // This assumes that the PinTable works and has every single pin
        public static void StepThroughCircuitWithNodes(int startingNodeId, int? previousPinId = null)
        {
            if (!PinTable.Any())
            {
                PopulatePinTable();
            }

            // Lookup NodeTable
            Node fromNode = NodeTable[startingNodeId];
            foreach(Pin fromPin in fromNode.Pins.Where(x => x.PinId != previousPinId))
            {
                if (fromPin.ToPinId.HasValue)
                {
                    int toPinId = fromPin.ToPinId.Value;

                    int toPinParentNodeId = PinTable[toPinId].ParentNodeId;

                    // TODO do useful things in each recursion
                    // e.g. build up route graph , build up UI, etc
                    StepThroughCircuitWithNodes(toPinParentNodeId, toPinId);
                }
            }
            // exit (no more nodes to traverse)
        }
        #endregion

        #region Private Methods
        private static void AddOrOverwriteNode(Node node)
        {
            if (NodeTable.ContainsKey(node.Id))
            {
                NodeTable[node.Id] = node;
            }
            else
            {
                NodeTable.Add(node.Id, node);
            }
        }

        private static void PopulatePinTable()
        {
            foreach (List<Pin> pins in NodeTable.Select(node => node.Value.Pins))
            {
                foreach(Pin pin in pins)
                {
                    PinTable.Add(pin.PinId, pin);
                }
            }
        }
        #endregion
    }
}
