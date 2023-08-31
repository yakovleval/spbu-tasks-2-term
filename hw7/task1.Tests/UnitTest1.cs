
namespace task1.Tests

{
    public class Tests
    {
        Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new(); 
        }

        [Test]
        public void TestInitialState()
        {

            Assert.That(calculator.NumberDisplay, Is.EqualTo("0"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestAddZero()
        {
            calculator.AddDigit("0");
            Assert.That(calculator.NumberDisplay, Is.EqualTo("0"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestAddDigit()
        {
            calculator.AddDigit("4");
            Assert.That(calculator.NumberDisplay, Is.EqualTo("4"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [TestCase("÷")]
        [TestCase("×")]
        [TestCase("+")]
        [TestCase("-")]
        public void TestAddOp(string op)
        {
            calculator.AddOp(op);
            Assert.That(calculator.NumberDisplay, Is.EqualTo("0"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo($"0 {op}"));
        }
        [TestCase("0", "÷", "1", "0")]
        [TestCase("2", "×", "-3", "-6")]
        [TestCase("9", "+", "8", "17")]
        [TestCase("-7", "-", "6", "-13")]
        public void TestEvaluate(string firstNumber, string op, string secondNumber, double answer)
        {
            double result = calculator.Evaluate(firstNumber, op, secondNumber);
            Assert.That(Math.Abs(result - answer) < 0.0001);
        }
        public void TestEvaluateThrowsException(string firstNumber, string op, string secondNumber, double answer)
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Evaluate("42", "÷", "0"));
        }
        [Test]
        public void TestEqualsOnFirstNumber()
        {
            calculator.AddDigit("4");
            calculator.Equals();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("4"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestEqualsOnSecondNumber()
        {
            calculator.AddDigit("2");
            calculator.AddOp("+");
            calculator.AddDigit("4");
            calculator.Equals();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("6"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestClear()
        {
            calculator.AddDigit("9");
            calculator.AddOp("+");
            calculator.AddDigit("5");
            calculator.AddOp("-");
            calculator.Clear();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("0"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestNegateZero()
        {
            calculator.Negate();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("0"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestNegateFirstNumber()
        {
            calculator.AddDigit("7");
            calculator.Negate();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("-7"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo(""));
        }
        [Test]
        public void TestNegateSecondNumber()
        {
            calculator.AddDigit("7");
            calculator.AddOp("-");
            calculator.AddDigit("7");
            calculator.Negate();
            Assert.That(calculator.NumberDisplay, Is.EqualTo("-7"));
            Assert.That(calculator.OperationDisplay, Is.EqualTo("7 -"));
        }
    }
}