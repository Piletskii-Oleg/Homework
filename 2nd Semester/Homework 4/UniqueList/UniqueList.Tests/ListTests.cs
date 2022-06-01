namespace UniqueList.Tests;

using System;
using System.Collections.Generic;
using NUnit.Framework;
using UniqueList.Exceptions;

public class ListTests
{
    private static IEnumerable<TestCaseData> Lists
        => new[]
        {
            new TestCaseData(new MyList<int>()),
            new TestCaseData(new MyUniqueList<int>())
        };

    [TestCaseSource(nameof(Lists))]
    public void InsertingInTheBeginningShouldWork(MyList<int> list)
    {
        list.Insert(0, 1);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(1, list[0]);
        });

        list.Insert(0, 2);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void InsertingInTheMiddleOfTheListShouldWork(MyList<int> list)
    {
        list.Add(1);
        list.Insert(1, 2);
        list.Insert(1, 3);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void InsertingAtTheEndShouldWork(MyList<int> list)
    {
        list.Insert(0, 0);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(1, list.Length);
            Assert.AreEqual(0, list[0]);
        });

        list.Insert(1, 1);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(2, list.Length);
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(1, list[1]);
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void DeleteAtShouldWork(MyList<int> list)
    {
        list.Add(1);
        list.Add(2);
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAt(3));

        list.DeleteAt(1);
        Assert.AreEqual(1, list.Length);
        Assert.Throws<IndexOutOfRangeException>(() => { _ = list[1]; });

        list.DeleteAt(0);
        Assert.AreEqual(0, list.Length);
        Assert.Throws<DeleteFromEmptyListException>(() => list.DeleteAt(0));
    }

    [TestCaseSource(nameof(Lists))]
    public void DeleteShouldWork(MyList<int> list)
    {
        list.Add(999);
        list.Add(43);
        list.Add(38);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(list.Length, 3);
            Assert.DoesNotThrow(() => list.Delete(999));
            Assert.AreEqual(list.Length, 2);

            Assert.DoesNotThrow(() => list.Delete(38));
            Assert.Throws<DeleteNonexistentElementException>(() => list.Delete(5));
            Assert.AreEqual(list.Length, 1);

            Assert.DoesNotThrow(() => list.Delete(43));
            Assert.AreEqual(list.Length, 0);
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void ChangingElementAtSetPositionShouldWork(MyList<int> list)
    {
        list.Add(0);
        list.Add(1);
        list.Add(2);
        list[0] = 3;
        list[1] = 4;
        list[2] = 5;
        Assert.Multiple(() =>
        {
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(5, list[2]);
        });
    }

    [TestCaseSource(nameof(Lists))]
    public void InsertingAtNegativePositionShouldThrowException(MyList<int> list)
    {
        list.Add(3);
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(-2, 5));
    }
}
