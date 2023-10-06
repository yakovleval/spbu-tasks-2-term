﻿namespace SkipList.Tests;

public class EnumeratorTests
{
    [Test]
    public void TestMoveNextAndCurrent()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3, 4, 5 };
        var enumerator = list.GetEnumerator();
        bool result = enumerator.MoveNext();
        Assert.That(result, Is.True);
        Assert.That(enumerator.Current, Is.EqualTo(1));
    }

    [Test]
    public void TestMoveNextToEndOfList()
    {
        SkipList<int> list = new SkipList<int> { };
        var enumerator = list.GetEnumerator();
        bool result = enumerator.MoveNext();
        Assert.That(result, Is.False);
    }

    [Test]
    public void TestMoveNextCurrentAtBeginning()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3 };
        var enumerator = list.GetEnumerator();
        int result;
        Assert.Throws<InvalidOperationException>(() => result = enumerator.Current);
    }

    [Test]
    public void TestMoveNextCurrentAfterEndOfArray()
    {
        SkipList<int> list = new SkipList<int> { };
        var enumerator = list.GetEnumerator();
        bool result = enumerator.MoveNext();
        Assert.That(result, Is.False);
        int current;
        Assert.Throws<InvalidOperationException>(() => current = enumerator.Current);
    }

    [Test]
    public void TestIvalidateEnumeratorReturnsCurrent()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3 };
        var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        list.Add(4);
        Assert.That(enumerator.Current, Is.EqualTo(1));
    }

    [Test]
    public void TestMoveNextAfterCollectionChanged()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3 };
        var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        list.Remove(3);
        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
    }
    [Test]
    public void TestReset()
    {
        SkipList<int> list = new SkipList<int> { 1, 2, 3 };
        var enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        enumerator.Reset();
        enumerator.MoveNext();
        Assert.That(enumerator.Current, Is.EqualTo(1));
    }
}