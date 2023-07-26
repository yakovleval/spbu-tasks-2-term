﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Exceptions
{
    public class GraphNotConnectedException : Exception
    {
        public GraphNotConnectedException(string message = "Graph is not connected") : base(message) { }
    }
}