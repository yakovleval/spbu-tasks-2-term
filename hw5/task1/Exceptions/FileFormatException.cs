using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Exceptions
{
    internal class FileFormatException : Exception
    {
        public FileFormatException(string message = "invalid file format") : base(message) { }
    }
}
