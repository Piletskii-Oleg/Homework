using System;
using UniqueList.Exceptions;
using NUnit.Framework;

namespace UniqueList.Tests;

public class UniqueListTests
{
    private MyUniqueList<int> list = new ();

    [SetUp]
    public void Setup()
    {
        list = new MyUniqueList<int>();
    }

    [Test]
    public void SameElementsShouldNotBeAdded()
    {
        list.Add(1);
        Assert.Multiple(() =>
        {
            Assert.Throws<AddExistingElementException>(() => list.Add(1));
            Assert.AreEqual(list.Length, 1);
            Assert.AreEqual(list[0], 1);
        });
    }

    [Test]
    public void SameElementsShouldNotBeInserted()
    {
        list.Insert(0, 1);
        Assert.Multiple(() =>
        {
            Assert.Throws<AddExistingElementException>(() => list.Insert(1, 1));
            Assert.AreEqual(list.Length, 1);
            Assert.AreEqual(list[0], 1);
        });
    }

    [Test]
    public void SameElementsShouldNotBeSet()
    {
        list.Add(1);
        list.Add(2);
        Assert.Multiple(() =>
        {
            Assert.Throws<AddExistingElementException>(() => list[0] = 2);
            Assert.AreEqual(list.Length, 2);
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
        });
    }

    [Test]
    public void SameElementCanBeDeletedAndThenInserted()
    {
        list.Add(0);
        list.Add(1);
        list.Add(2);
        list.DeleteAt(2);
        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => list.Add(2));
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(list[0], 0);
            Assert.AreEqual(list[1], 1);
            Assert.AreEqual(list[2], 2);
        });
    }
}