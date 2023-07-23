using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Operator : IASTNode
    {
        private readonly double DELTA = 1e-6;
        private char op { get; }
        IASTNode leftOperand { get; set; }
        IASTNode rightOperand { get; set; }
        public Operator(char op, IASTNode? leftOperand, IASTNode? rightOperand)
        {
            if (!"+-*/".Contains(op))
                throw new InvalidOperationException();
            this.op = op;
            if (leftOperand == null || rightOperand == null)
                throw new InvalidExpressionException();
            this.leftOperand = leftOperand;
            this.rightOperand = rightOperand;
        }
        public double Evaluate()
        {
            if (leftOperand == null || rightOperand == null)
                throw new InvalidExpressionException();
            double leftResult = leftOperand.Evaluate();
            double rightResult = rightOperand.Evaluate();
            switch (op)
            {
                case '+':
                    return leftResult + rightResult;
                case '-':
                    return leftResult - rightResult;
                case '*':
                    return leftResult * rightResult;
                case '/':
                    if (rightResult < DELTA)
                        throw new DivideByZeroException();
                    return leftResult / rightResult;
                default:
                    throw new InvalidOperationException();
            }
        }
        public override string ToString()
        {
            if (leftOperand == null || rightOperand == null)
                throw new Exception();
            return $"( {op} {leftOperand.ToString()} {rightOperand.ToString()} )";
        }
    }
}
