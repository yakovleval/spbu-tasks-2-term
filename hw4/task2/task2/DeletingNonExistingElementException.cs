using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class DeletingNonExistingElementException : Exception
    {
        public DeletingNonExistingElementException() { }
        public DeletingNonExistingElementException(string message) : base(message) { }
    }
}
