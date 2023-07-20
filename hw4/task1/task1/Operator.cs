using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Operator : IASTNode
    {
        private readonly string ALLOWED_OPERATORS = "+-*/";
        public Operator(char op)
        {
            if (!ALLOWED_OPERATORS.Contains(op))
                throw new Exception("incorret operator");
            this.op = op;
        }
        public double Evaluate()
        {

        }
    }
}
