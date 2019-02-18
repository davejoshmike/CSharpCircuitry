﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.CircuitryFlowController.Shared
{
    public class Node
    {
        Node ToNode { get; set; }
        Node FromNode { get; set; }

        public Node(Node toNode, Node fromNode)
        {
            ToNode = toNode;
            FromNode = fromNode;
        }
    }
}