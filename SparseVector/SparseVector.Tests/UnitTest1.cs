namespace SparseVector.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> VectorsForAdditionTest
            => new TestCaseData[]
            {
            new TestCaseData(new SparseVector(), new SparseVector(), new SparseVector()),
            new TestCaseData(
                new SparseVector(new int[] {0, 1, 42}),
                new SparseVector(new int[] {0, -1, -42}),
                new SparseVector(new int[] {0, 0, 0})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1}),
                new SparseVector(new int[] {1}),
                new SparseVector(new int[] {2})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1, 0}),
                new SparseVector(new int[] {0, 2}),
                new SparseVector(new int[] {1, 2})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1, 1}),
                new SparseVector(new int[] {0, 0}),
                new SparseVector(new int[] {1, 1})
            ),
            };

        [TestCaseSource(nameof(VectorsForAdditionTest))]
        public void TestAddition(SparseVector first, SparseVector second, SparseVector expected)
        {
            Assert.That(first.Add(second).IsEqual(expected), Is.True);
        }

        private static IEnumerable<TestCaseData> VectorsForSubtractionTest
            => new TestCaseData[]
            {
            new TestCaseData(new SparseVector(), new SparseVector(), new SparseVector()),
            new TestCaseData(
                new SparseVector(new int[] {0, 1, 42}),
                new SparseVector(new int[] {0, 1, 42}),
                new SparseVector(new int[] {0, 0, 0})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1}),
                new SparseVector(new int[] {1}),
                new SparseVector(new int[] {0})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1, 0}),
                new SparseVector(new int[] {0, 2}),
                new SparseVector(new int[] {1, -2})
            ),
            new TestCaseData(
                new SparseVector(new int[] {1, 2, 3, 4}),
                new SparseVector(new int[] {1, 1, 1, 1}),
                new SparseVector(new int[] {0, 1, 2, 3})
            ),
            };

        [TestCaseSource(nameof(VectorsForSubtractionTest))]
        public void TestSubtraction(SparseVector first, SparseVector second, SparseVector expected)
        {
            Assert.That(first.Subtract(second).IsEqual(expected), Is.True);
        }

        private static IEnumerable<TestCaseData> VectorsForMultiplicationTest
            => new TestCaseData[]
            {
            new TestCaseData(
                new SparseVector(new int[] {0, 0, 0}),
                new SparseVector(new int[] {0, 0, 0}),
                0
            ),
            new TestCaseData(
                new SparseVector(new int[] {1, 2, 3}),
                new SparseVector(new int[] {4, 5, 6}),
                32
            ),
            new TestCaseData(
                new SparseVector(),
                new SparseVector(),
                0
            )
            };

        [TestCaseSource(nameof(VectorsForMultiplicationTest))]
        public void TestMultiplication(SparseVector first, SparseVector second, int expected)
        {
            Assert.That(first.ScalarMultiply(second), Is.EqualTo(expected));
        }

        [Test]
        public void TestOperationOnVectorsOfDifferentSize()
        {
            SparseVector vector1 = new SparseVector(new int[] { 1, 2, 3 });
            SparseVector vector2 = new SparseVector(new int[] { 1, 2, 3, 4});
            Assert.Throws<InvalidOperationException>(() => vector1.Add(vector2));
            Assert.Throws<InvalidOperationException>(() => vector1.Subtract(vector2));
            Assert.Throws<InvalidOperationException>(() => vector1.ScalarMultiply(vector2));
        }
    }
}