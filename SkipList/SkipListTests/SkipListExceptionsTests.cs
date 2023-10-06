namespace SkipList.Tests;

public class SkipListExceptionsTests
{
    [Test]
    public void TestSquareBracketsOutOfRangeException()
    {
        SkipList<int> list = new();
        int result;
        Assert.Throws<IndexOutOfRangeException>(() => result = list[0]);
        Assert.Throws<IndexOutOfRangeException>(() => result = list[-1]);
    }

    [Test]
    public void TestCopyToIndexOutOfRangeException()
    {
        SkipList<int> list = new SkipList<int>{ 1, 2, 3, 4, 5 };
        int[] array = new int[5];
        Assert.Throws<IndexOutOfRangeException>(() => list.CopyTo(array, array.Length));
        Assert.Throws<IndexOutOfRangeException>(() => list.CopyTo(array, -2));
    }

    [Test]
    public void TestCopyToNotEnoughSpace()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3, 4, 5 };
        int[] array = new int[4];
        Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));
    }
}
