namespace task1.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestMapArbitraryList()
        {
            var list = new List<int>() { 1, 2, 3 };
            var result = Functions.Map(list, x => x * 2);
            Assert.IsTrue(result.SequenceEqual(new List<int> { 2, 4, 6 }));
        }
        [Test]
        public void TestMapEmptyList()
        {
            var list = new List<int>();
            var result = Functions.Map(list, x => x * 2);
            Assert.IsTrue(result.SequenceEqual(new List<int>()));
        }
        [Test]
        public void TestFilterArbitrary()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var result = Functions.Filter(list, x => x % 2 == 0);
            Assert.IsTrue(result.SequenceEqual(new List<int>() { 1, 3, 5 }));
        }
        [Test]
        public void TestFilterEmpty()
        {
            var list = new List<int>();
            var result = Functions.Filter(list, x => x % 2 == 0);
            Assert.IsTrue(result.SequenceEqual(new List<int>()));
        }
        [Test]
        public void TestFoldArbitrary()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var result = Functions.Fold(list, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(120, result);
        }
        [Test]
        public void TestFoldEmpty()
        {
            var list = new List<int>();
            int acc = 42;
            var result = Functions.Fold(list, acc, (acc, elem) => acc * elem);
            Assert.AreEqual(acc, result);
        }
    }
}