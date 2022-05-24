namespace SkipList.Tests;

using System;
using NUnit.Framework;

public class SkipListTests
{
    [Test]
    public void AddingPutsElementInCorrectOrder()
    {
        var list = new SkipList<int> { 3, 5, 1, 7, 9, 0 };
        var array = new[] { 0, 1, 3, 5, 7, 9 };
        for (int i = 0; i < 6; i++)
        {
            Assert.AreEqual(array[i], list[i]);
        }
    }

    [Test]
    public void AddThrowsExceptionWhenSameElementsAreAdded()
    {
        var list = new SkipList<int> { 1 };
        Assert.Throws<InvalidOperationException>(() => list.Add(1));
    }

    [Test]
    public void AddingSmallerElementsThanMinDoesNotBreakTheList()
    {
        var list = new SkipList<int> { 7, 6, 5, 4, 3, 2, 1 };
        var array = new[] { 1, 2, 3, 4, 5, 6, 7 };
        for (int i = 0; i < 7; i++)
        {
            Assert.AreEqual(array[i], list[i]);
        }
    }

    [Test]
    public void SetAndInsertThrowExceptions()
    {
        var list = new SkipList<int> { 3 };
        Assert.Throws<NotSupportedException>(() => list[0] = 4);
        Assert.Throws<NotSupportedException>(() => list.Insert(0, 4));
    }

    [Test]
    public void SameElementCanBeRemovedAndThenAdded()
    {
        var list = new SkipList<int> { 1, 2, 3 };
        list.Remove(3);
        Assert.DoesNotThrow(() => list.Add(3));
        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(3, list[2]);
    }

    [Test]
    public void CountGivesCorrectValueAfterAdding()
    {
        var list = new SkipList<int> { 7, 6, 5, 4, 3, 2, 1 };
        Assert.AreEqual(7, list.Count);
    }

    [Test]
    public void CountGivesCorrectValueAfterRemovingAndAdding()
    {
        var list = new SkipList<int> { 7, 6, 5, 4, 3, 2, 1 };
        list.Remove(3);
        list.Remove(4);
        Assert.AreEqual(5, list.Count);
        list.Add(9);
        Assert.AreEqual(6, list.Count);
    }

    [Test]
    public void IndexOfWorksCorrectly()
    {
        var list = new SkipList<int> { 3, 6, 1, 5, 2 };
        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual(i, list.IndexOf(list[i]));
        }
    }

    [Test]
    public void IndexOfWorksWhenElementsAreRemoved()
    {
        var list = new SkipList<int> { 3, 6, 1, 5 };
        list.Remove(3);
        Assert.AreEqual(0, list.IndexOf(1));
        Assert.AreEqual(1, list.IndexOf(5));
        Assert.AreEqual(2, list.IndexOf(6));
        list.Remove(1);
        Assert.AreEqual(0, list.IndexOf(5));
        Assert.AreEqual(1, list.IndexOf(6));
    }

    [Test]
    public void GettingLastElementAfterRemovingAtLastIndexThrows()
    {
        var list = new SkipList<int> { 3, 6, 1, 5 };
        list.RemoveAt(3);
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[3]);
    }

    [Test]
    public void OrderOfElementsIsChangedAfterRemoveAtCorrectly()
    {
        var list = new SkipList<int> { 1, 3, 5, 7, 9 };
        list.RemoveAt(1);
        Assert.AreEqual(5, list[1]);
        list.RemoveAt(1);
        Assert.AreEqual(7, list[1]);
        list.RemoveAt(1);
        Assert.AreEqual(9, list[1]);
        list.RemoveAt(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
    }

    [Test]
    public void WholeListCanBeRemovedWithRemoveAt()
    {
        var list = new SkipList<int> { 1, 3, 5 };
        list.RemoveAt(2);
        list.RemoveAt(1);
        list.RemoveAt(0);
        Assert.AreEqual(0, list.Count);
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[0]);
    }

    [Test]
    public void RemoveAtWorksCorrectlyOnFirstElement()
    {
        var list = new SkipList<int> { 1, 3, 5 };
        list.RemoveAt(0);
        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(3, list[0]);
        list.RemoveAt(0);
        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(5, list[0]);
    }

    [Test]
    public void ContainsWorksProperly()
    {
        var list = new SkipList<int> { 1, 3, 5, 9 };
        for (int i = 0; i < 3; i++)
        {
            Assert.IsTrue(list.Contains(list[i]));
        }
    }

    [Test]
    public void ContainsWorksProperlyWhenElementsAreDeleted()
    {
        var list = new SkipList<int> { 1, 3, 5, 9, 11 };
        list.Remove(5);
        for (int i = 0; i < 3; i++)
        {
            Assert.IsTrue(list.Contains(list[i]));
        }

        list.RemoveAt(0);
        for (int i = 0; i < 2; i++)
        {
            Assert.IsTrue(list.Contains(list[i]));
        }
    }

    [Test]
    public void ClearWorksCorrectly()
    {
        var list = new SkipList<int> { 1, 3, 5, 9, 11 };
        list.Clear();
        Assert.AreEqual(0, list.Count);
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[0]);
    }

    [Test]
    public void CopyToWorksCorrectlyWhenAddingToBeginning()
    {
        var array = new int[4];
        var list = new SkipList<int> { 1, 3, 5, 9 };
        Assert.DoesNotThrow(() => list.CopyTo(array, 0));
    }

    [Test]
    public void CopyingToInappropriateArraysThrowsException()
    {
        int[] smallArray = new int[3];
        int[] bigArray = new int[5];
        var list = new SkipList<int> { 1, 3, 5, 7 };
        Assert.Throws<ArgumentException>(() => list.CopyTo(smallArray, 0));
        Assert.Throws<ArgumentException>(() => list.CopyTo(bigArray, 2));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(bigArray, -5));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(bigArray, 34));
    }

    [Test]
    public void ForeachWorksCorrectly()
    {
        var list = new SkipList<int> { 1, 3, 5, 7 };
        var arr = new[] { 1, 3, 5, 7 };
        int i = 0;
        foreach (var item in list)
        {
            Assert.AreEqual(arr[i], item);
            i++;
        }
    }
}