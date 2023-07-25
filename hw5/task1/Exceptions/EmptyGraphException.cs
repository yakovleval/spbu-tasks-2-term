using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Exceptions
{
    internal class EmptyGraphException : Exception
    {
        public EmptyGraphException(string message = "Graph cannot be empty") : base(message) { }
    }
}
