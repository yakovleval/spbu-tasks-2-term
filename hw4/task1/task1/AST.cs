using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task1
{
    public class AST
    {
        private IASTNode root;

        private IASTNode? BuildTree(string expression, ref int pos)
        {
            IASTNode? node = null;
            for (; pos < expression.Length; pos++)
            {
                switch(expression[pos])
                {
                    case ' ':
                        continue;
                    case '(':
                        char op;
                        IASTNode? leftOperand;
                        IASTNode? rightOperand;
                        pos++;
                        while (pos < expression.Length && expression[pos] == ' ')
                            pos++;
                        if (pos >= expression.Length)
                            throw new InvalidExpressionException();
                        if ("+-*/".Contains(expression[pos]))
                            op = expression[pos];
                        else
                            throw new InvalidOperationException();
                        pos++;
                        leftOperand = BuildTree(expression, ref pos);
                        rightOperand = BuildTree(expression, ref pos);
                        node = new Operator(op, leftOperand, rightOperand);
                        for (; pos < expression.Length && expression[pos] == ' '; pos++) ;
                        if (pos >= expression.Length || expression[pos] != ')')
                            throw new InvalidExpressionException();
                        pos++;
                        return node;
                    case '-':
                    case '+':
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
                        int numberLength = 0;
                        if (expression[pos] == '+' || expression[pos] == '-')
                            numberLength++;
                        while (pos + numberLength < expression.Length && char.IsDigit(expression[pos + numberLength]))
                            numberLength++;
                        int result;
                        bool success = int.TryParse(expression.Substring(pos, numberLength), out result);
                        if (!success)
                            throw new InvalidExpressionException();
                        node = new Value(result);
                        pos += numberLength;
                        return node;
                    default:
                        throw new InvalidExpressionException();
                }
            }
            for (; pos < expression.Length; pos++)
            {
                if (expression[pos] == ' ')
                    continue;
                else
                    throw new InvalidExpressionException();
            }
            return node;
        }
        public AST(string expression)
        {
            int pos = 0;
            IASTNode? result = BuildTree(expression, ref pos) ?? throw new InvalidExpressionException();
            root = result;
        }
        public double Evaluate() => root.Evaluate();
        public override string ToString() => root.ToString();
    }
}
