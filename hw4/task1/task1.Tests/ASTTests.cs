using System.Data;
using System.Linq.Expressions;
using System.Numerics;
using NUnit.Framework;


namespace task1
{
    [TestClass]
    public class ASTTests
    {
        [TestCase("0", ExpectedResult = 0)]
        [TestCase("-1", ExpectedResult = -1)]
        [TestCase("(+ 2 2)", ExpectedResult = 4)]
        [TestCase("(* 2 3)", ExpectedResult = 6)]
        [TestCase("(- 2 3)", ExpectedResult = -1)]
        [TestCase("(/ 6 3)", ExpectedResult = 2)]
        [TestCase("(* (+ 1 1) 2)", ExpectedResult = 4)]
        [TestCase("( / ( * 2 (+ 1 1) ) (- 18 16) )", ExpectedResult = 2)]
        [TestCase("( / ( - 2 (- 1 -1) ) (+ 2 0) )", ExpectedResult = 0)]
        public double TestValidExpression(string expression)
        {
            AST tree = new(expression);
            return tree.Evaluate();
            
        }
        [TestCaseSource(nameof(InvalidExpressions))]
        public void TestInvalidExpressionException(string expression)
        {
            NUnit.Framework.Assert.Throws<InvalidExpressionException>(() => new AST(expression));
        }
        private static IEnumerable<TestCaseData> InvalidExpressions
            => new TestCaseData[]
            {
                new TestCaseData (""),
                new TestCaseData ("*"),
                new TestCaseData ("+ 2 2"),
                new TestCaseData ("(+ 2 2"),
                new TestCaseData ("+ 2 2)"),
                new TestCaseData ("(+ 2 )"),
                new TestCaseData ("( / ( * 2 (+ 1 )1) ) 2 )"),
            };
        [TestCaseSource(nameof(InvalidOperations))]
        public void TestInvalidOperationException(string expression)
        {
            NUnit.Framework.Assert.Throws<InvalidOperationException>(() => new AST(expression));
        }
        private static IEnumerable<TestCaseData> InvalidOperations
            => new TestCaseData[]
            {
                new TestCaseData ("(# 2 2)"),
                new TestCaseData ("(2 2)"),
                new TestCaseData ("( / ( * 2 (+ 1 1) ) ($ 0 0) )"),
            };
        [TestMethod]
        public void TestDivisionByZero()
        {
            AST tree = new("( / ( + 2 (- 1 -1) ) 0 )");
            NUnit.Framework.Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
        }
    }
}