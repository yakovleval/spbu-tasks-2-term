using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Value : IASTNode
    {
        private int value { get; }
        public Value(int value) => this.value = value;
        public double Evaluate() => value;
        public override string ToString() => value.ToString();
    }
}
