namespace hw2task2.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyInput()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            double arrayResult = arrayCalculator.Evaluate("");
            double listResult = listCalculator.Evaluate("");
            Assert.AreEqual(0, arrayResult);
            Assert.AreEqual(0, listResult);
        }
        [TestMethod]
        public void TestOneNumber()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            double arrayResult = arrayCalculator.Evaluate("-100");
            double listResult = listCalculator.Evaluate("-100");
            Assert.AreEqual(-100, arrayResult);
            Assert.AreEqual(-100, listResult);
        }
        [TestMethod]
        public void TestEvaluate()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            double arrayResult = arrayCalculator.Evaluate("1 2 3 + *");
            double listResult = listCalculator.Evaluate("1 2 3 + *");
            Assert.AreEqual(5, arrayResult);
            Assert.AreEqual(5, listResult);

            arrayResult = arrayCalculator.Evaluate("2 3 4 + * 5 -");
            listResult = listCalculator.Evaluate("2 3 4 + * 5 -");
            Assert.AreEqual(9, arrayResult);
            Assert.AreEqual(9, listResult);

            arrayResult = arrayCalculator.Evaluate("2 3 * 4 5 * -");
            listResult = listCalculator.Evaluate("2 3 * 4 5 * -");
            Assert.AreEqual(-14, arrayResult);
            Assert.AreEqual(-14, listResult);
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            Assert.ThrowsException<ArithmeticException>(() => arrayCalculator.Evaluate("-5 0 /"));
            Assert.ThrowsException<ArithmeticException>(() => listCalculator.Evaluate("-5 0 /"));
        }

        [TestMethod]
        public void TestInvalidOperation()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            Assert.ThrowsException<InvalidOperationException>(() => arrayCalculator.Evaluate("1 +"));
            Assert.ThrowsException<InvalidOperationException>(() => listCalculator.Evaluate("1 +"));
            Assert.ThrowsException<InvalidOperationException>(() => arrayCalculator.Evaluate("1 2 + +"));
            Assert.ThrowsException<InvalidOperationException>(() => listCalculator.Evaluate("1 2 + +"));
        }

        [TestMethod]
        public void TestBadInput()
        {
            Calculator arrayCalculator = new Calculator(new ArrayStack<double>(100));
            Calculator listCalculator = new Calculator(new ListStack<double>());

            Assert.ThrowsException<ArgumentException>(() => arrayCalculator.Evaluate("1 2 unknown-operator"));
            Assert.ThrowsException<ArgumentException>(() => listCalculator.Evaluate("1 2 unknown-operator"));
        }
    }
}