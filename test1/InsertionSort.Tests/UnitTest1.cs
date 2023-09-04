using System.ComponentModel;
using System.Linq;

namespace InsertionSort.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private bool AreArraysEqual<T>(T[] array1, T[] array2) where T : IComparable
        {
            if (array1.Length != array2.Length)
                return false;
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i].CompareTo(array2[i]) != 0)
                    return false;
            }
            return true;
        }

        class ReverseOrderComparer<T> : IComparer<T> where T : IComparable
        {
            public int Compare(T x, T y) => x.CompareTo(y) * -1;
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 2, 1, 1, 1 }, new int[] { 1, 1, 1, 2 })]
        public void TestIntArrayWithDefaultAndReverseOrderComparer(int[] arrayToSort, int[] expectedArray)
        {
            List<int> resultList = InsertionSort.Sort(arrayToSort.ToList<int>(), Comparer<int>.Default);
            int[] resultArray = resultList.ToArray();
            Assert.That(AreArraysEqual(resultArray, expectedArray), Is.True);

            IComparer<int> reverseOrder = new ReverseOrderComparer<int>();
            List<int> resultListReverseOrder = InsertionSort.Sort(arrayToSort.ToList<int>(), reverseOrder);
            resultArray = resultListReverseOrder.ToArray();
            Array.Reverse(expectedArray);
            Assert.That(AreArraysEqual(resultArray, expectedArray), Is.True);
        }

        [TestCase(new string[] { }, new string[] { })]
        [TestCase(new string[] { "" }, new string[] { "" })]
        [TestCase(new string[] { "abcd" }, new string[] { "abcd" })]
        [TestCase(new string[] { "d", "c", "b", "a" }, new string[] { "a", "b", "c", "d" })]
        [TestCase(new string[] { "xyz", "bar", "foo" }, new string[] { "bar", "foo", "xyz" })]
        public void TestStringArrayWithDefaultAndReverseOrderComparer(string[] arrayToSort, string[] expectedArray)
        {
            List<string> resultList = InsertionSort.Sort(arrayToSort.ToList<string>(), Comparer<string>.Default);
            string[] resultArray = resultList.ToArray();
            Assert.That(AreArraysEqual(resultArray, expectedArray), Is.True);

            IComparer<string> reverseOrder = new ReverseOrderComparer<string>();
            List<string> resultListReverseOrder = InsertionSort.Sort(arrayToSort.ToList<string>(), reverseOrder);
            resultArray = resultListReverseOrder.ToArray();
            Array.Reverse(expectedArray);
            Assert.That(AreArraysEqual(resultArray, expectedArray), Is.True);
        }
    }
}