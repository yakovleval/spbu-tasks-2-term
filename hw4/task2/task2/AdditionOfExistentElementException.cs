using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class AdditionOfExistentElementException : Exception
    {
        public AdditionOfExistentElementException() { }
        public AdditionOfExistentElementException(string message) : base(message) { }
    }
}
