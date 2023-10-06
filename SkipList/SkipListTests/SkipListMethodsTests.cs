namespace SkipList.Tests;

public class SkipListMethodsTests
{
    [Test]
    public void TestAddAndContains()
    {
        SkipList<int> list = new();
        list.Add(-15);
        Assert.That(list.Contains(0), Is.False);
        Assert.That(list.Contains(-15), Is.True);
    }

    [Test]
    public void TestRemoveAndContains()
    {
        var list = new SkipList<int>{1};
        list.Remove(1);
        Assert.That(list.Contains(1), Is.False);
    }

    [Test]
    public void TestRemoveAtAndContains()
    {
        var list = new SkipList<int> { 1, 1, 2, 3 };
        list.RemoveAt(2);
        Assert.That(list.Contains(2), Is.False);
    }

    [TestCase(new int[] { }, 0)]
    [TestCase(new int[] { 1 }, 1)]
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
    public void TestCount(int[] elements, int expectedSize)
    {
        SkipList<int> list = new();
        foreach (var element in elements)
        {
            list.Add(element);
        }
        Assert.That(list.Count(), Is.EqualTo(expectedSize));
    }

    [Test]
    public void TestSquareBrackets()
    {
        SkipList<int> list = new SkipList<int> { 5, 4, 3, 2, 1 };
        for (int i = 0; i < list.Count; i++)
        {
            Assert.That(list[i], Is.EqualTo(i + 1));
        }
    }

    [TestCase(new int[] { }, new int[] { })]
    [TestCase(new int[] { 2, 2, 1, 1, 3, 3, 3, 3 }, new int[] { 1, 1, 2, 2, 3, 3, 3, 3 })]
    [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
    public void TestForEachLoop(int[] elementsToAdd, int[] expectedOrder)
    {
        SkipList<int> list = new();
        foreach (var element in elementsToAdd)
        {
            list.Add(element);
        }
        List<int> result = new();
        foreach (var element in list)
        {
            result.Add(element);
        }
        Assert.That(result.Count, Is.EqualTo(expectedOrder.Length));
        for (int i = 0; i < result.Count; i++)
        {
            Assert.That(result[i], Is.EqualTo(expectedOrder[i]));
        }
    }

    [Test]
    public void TestCopyTo()
    {
        SkipList<int> list = new SkipList<int> { 5, 4, 3, 2, 1 };
        int[] array = new int[7];
        list.CopyTo(array, 2);
        Assert.That(array, Is.EqualTo(new int[] { 0, 0, 1, 2, 3, 4, 5 }));
    }

    [Test]
    public void TestIndexOf()
    {
        SkipList<int> list = new SkipList<int> { 5, 4, 3, 2, 1 };
        Assert.That(list.IndexOf(3), Is.EqualTo(2));
        Assert.That(list.IndexOf(0), Is.EqualTo(-1));
    }

    [Test]
    public void TestClear()
    {
        SkipList<int> list = new SkipList<int> { 5, 4, 3, 2, 1 };
        list.Clear();
        Assert.That(list.Count, Is.EqualTo(0));
        for (int i = 1; i <= 5; i++)
        {
            Assert.That(list.Contains(i), Is.False);
        }
    }
}