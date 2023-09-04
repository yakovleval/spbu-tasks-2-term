﻿using System.Data;

namespace Task1
{
    /// <summary>
    /// operation node of AST tree, implements IASTNode inteface, stores the operation and two operands
    /// </summary>
    public class OperatorNode : IASTNode
    {
        private readonly double DELTA = 1e-6;
        private char op { get; }
        private IASTNode leftOperand { get; set; }
        private IASTNode rightOperand { get; set; }

        public OperatorNode(char op, IASTNode? leftOperand, IASTNode? rightOperand)
        {
            if (!"+-*/".Contains(op))
                throw new InvalidOperationException();
            this.op = op;
            if (leftOperand == null || rightOperand == null)
                throw new InvalidExpressionException();
            this.leftOperand = leftOperand;
            this.rightOperand = rightOperand;
        }

        /// <summary>
        /// applies an operator to its two operands
        /// </summary>
        /// <returns>the result of the operation</returns>
        /// <exception cref="InvalidExpressionException">thrown if at least one of the operands is absent</exception>
        /// <exception cref="DivideByZeroException">thrown if expression contains division by zero</exception>
        /// <exception cref="InvalidOperationException">thrown if expression contains invalid operation</exception>
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

        /// <summary>
        /// prints the operator and its two operands
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidExpressionException">thrown if at least one of the operands is absent</exception>
        public override string ToString()
        {
            if (leftOperand == null || rightOperand == null)
                throw new InvalidExpressionException();
            return $"( {op} {leftOperand.ToString()} {rightOperand.ToString()} )";
        }
    }
}