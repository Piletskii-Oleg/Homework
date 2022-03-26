using System;
using NUnit.Framework;

namespace UniqueList.Tests;

public class ListTests
{
    private MyList<int> list = new MyList<int>();

    [SetUp]
    public void Setup()
    {
        list = new MyList<int>();
    }

    [Test]
    public void InsertingInTheMiddleOfTheListShouldWork()
    {
        list.Add(1);
        list.Insert(1, 2);
        list.Insert(1, 3);
        Assert.AreEqual(1, list[0]);
        Assert.AreEqual(3, list[1]);
        Assert.AreEqual(2, list[2]);
    }

    [Test]
    public void DeleteShouldWork()
    {
        list.Add(1);
        list.Add(2);
        Assert.Throws<IndexOutOfRangeException>(() => list.Delete(3));
        list.Delete(1);
        Assert.AreEqual(1, list.Length);
        Assert.Throws<IndexOutOfRangeException>(() => { _ = list[1]; });
        list.Delete(0);
        Assert.AreEqual(0, list.Length);
        Assert.Throws<InvalidOperationException>(() => { _ = list[0]; });
        Assert.Throws<InvalidOperationException>(() => list.Delete(0));
    }

    [Test]
    public void InsertingInTheBeginningShouldWork()
    {
        list.Insert(0, 1);
        Assert.AreEqual(1, list.Length);
        Assert.AreEqual(1, list[0]);
        list.Insert(0, 2);
        Assert.AreEqual(2, list.Length);
        Assert.AreEqual(2, list[0]);
        Assert.AreEqual(1, list[1]);
    }

    [Test]
    public void InsertingAtTheEndShouldWork()
    {
        list.Insert(0, 0);
        Assert.AreEqual(1, list.Length);
        Assert.AreEqual(0, list[0]);
        list.Insert(1, 1);
        Assert.AreEqual(2, list.Length);
        Assert.AreEqual(0, list[0]);
        Assert.AreEqual(1, list[1]);
    }

    [Test]
    public void ChangingElementAtSetPositionShouldWork()
    {
        list.Add(0);
        list.Add(1);
        list.Add(2);
        list[0] = 3;
        list[1] = 4;
        list[2] = 5;
        Assert.AreEqual(3, list[0]);
        Assert.AreEqual(4, list[1]);
        Assert.AreEqual(5, list[2]);
    }
}
