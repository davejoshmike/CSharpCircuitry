using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mid.Circuitry.Shared.Utilities;

namespace Mid.Circuitry.Shared
{
    public class Circuit
    {
        #region Fields
        public int CircuitId;
        public string CircuitName;
        public int StartingNodeId;
        public List<Node> Nodes;
        #endregion

        #region Constructor
        public Circuit(int startingNodeId, List<Node> nodes, string circuitName = "")
        {
            CircuitId = UniqueIdGenerator.GenerateCircuitId();
            CircuitName = string.IsNullOrEmpty(circuitName)
                ? $"{GetType().Name}{CircuitId}"
                : $"{circuitName}{CircuitId}";
            StartingNodeId = startingNodeId;
            Nodes = nodes;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($@"Circuit {CircuitId}
[
    Name: {CircuitName}
    Nodes: ");

            foreach (Node node in Nodes)
            {
                builder.AppendLine(node.ToString());
            }

            builder.AppendLine("]");
            return builder.ToString();
        }

        #endregion
    }
}
