using System.Data;

namespace task1
{
    /// <summary>
    /// abstract syntax tree data structure for expression evaluation
    /// </summary>
    public class AST
    {
        private IASTNode root;

        /// <summary>
        /// recursively builds the tree from given expression
        /// </summary>
        /// <param name="expression">expression to build the tree from</param>
        /// <param name="pos">current position in the expression</param>
        /// <returns></returns>
        /// <exception cref="InvalidExpressionException">thrown if syntax of the expression is invalid</exception>
        /// <exception cref="InvalidOperationException">thrown if operation is invalid</exception>
        private IASTNode? BuildTree(string expression, ref int pos)
        {
            IASTNode? node = null;
            for (; pos < expression.Length; pos++)
            {
                switch (expression[pos])
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
                        node = new OperatorNode(op, leftOperand, rightOperand);
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
                        node = new ValueNode(result);
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

        /// <summary>
        /// evaluates the tree
        /// </summary>
        /// <returns>result of the evaluation</returns>
        public double Evaluate() => root.Evaluate();

        /// <summary>
        /// converts the tree to string
        /// </summary>
        /// <returns>tree converted to string</returns>
        public override string ToString() => root.ToString();
    }
}
