﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Circuitry.Shared
{
    public class Graph
    {
        #region Fields
        public int GraphId { get; set; }
        public List<Arrow> Arrows { get; set; }
        #endregion

        #region Constructor
        public Graph(List<Arrow> arrows)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
