namespace task2.Tests;

public class CommonTests
{
    private static IEnumerable<TestCaseData> Lists()
        => new TestCaseData[]
        {
            new TestCaseData(new DefaultList()),
            new TestCaseData(new UniqueList())
        };

    [TestCaseSource(nameof(Lists))]
    public void TestAddAndRemoveOneElement(DefaultList list)
    {
        list.Add(1);
        Assert.IsTrue(list.Remove(1));
    }

    [TestCaseSource(nameof(Lists))]
    public void TestReplaceInEmptyList(DefaultList list)
    {
        Assert.IsFalse(list.Replace(1, 0));
        Assert.IsFalse(list.Replace(1, 1));
    }

    [TestCaseSource(nameof(Lists))]
    public void TestReplacePositionOutOfBounds(DefaultList list)
    {
        list.Add(1);
        list.Add(2);
        Assert.IsFalse(list.Replace(1, 3));
        Assert.IsFalse(list.Replace(1, 4));
    }

    [TestCaseSource(nameof(Lists))]
    public void TestReplaceELementWithItself(DefaultList list)
    {
        list.Add(1);
        Assert.IsTrue(list.Replace(1, 0));
    }

    [TestCaseSource(nameof(Lists))]
    public void TestReplaceELementWithArbitrary(DefaultList list)
    {
        list.Add(1);
        Assert.IsTrue(list.Replace(42, 0));
    }
}