using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task1
{
    internal class AST
    {
        private IASTNode root;

        private IASTNode BuildTree(string expression, ref int pos)
        {
            IASTNode node;
            for (pos = 0; pos < expression.Length; pos++)
            {
                switch(expression[i])
                {
                    case ' ':
                        continue;
                    case '(':
                        char op;
                        IASTNode leftOperand = null;
                        IASTNode rightOperand = null;
                        for (; pos < expression.Length; pos++)
                        {
                            if (expression[pos] == ' ')
                                continue;
                            if ("+-*/".Contains(expression[pos]))
                                op = expression[pos];
                            else
                                throw new InvalidExpressionException("invalid expression");
                            leftOperand = BuildTree(expression, ref pos);
                            rightOperand = BuildTree(expression, ref pos);
                            node = new Operator(op, leftOperand, rightOperand);
                        }
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        int numberLength = pos + 1;
                        while (numberLength < expression.Length && char.IsDigit(expression[pos]))
                        break;
                    case ')':
                        return node;

                }
            }
        }
        public AST(string expression)
        {
            root = BuildTree(expression, 0);
        }
    }
}
