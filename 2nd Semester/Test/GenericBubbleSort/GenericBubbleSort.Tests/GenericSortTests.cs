namespace GenericBubbleSort.Tests;

using System;
using NUnit.Framework;
using GenericBubbleSort;
using System.Collections.Generic;

public class Tests
{
    [Test]
    public void IntArrayWithDefaultComparerIsSortedCorrectly()
    {
        var array = new[] { 3, 9, 123, 586, 33 };
        var bubbleSorted = BubbleSort.Sort(array, null);
        Array.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(array[i], bubbleSorted[i]);
        }
    }

    [Test]
    public void IntArrayWithReverseComparerIsSortedCorrectly()
    {
        var array = new[] { 3, 9, 123, 586, 33 };
        var bubbleSorted = BubbleSort.Sort(array, new Comparers.ReverseComparer());
        Array.Sort(array, new Comparers.ReverseComparer());
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(array[i], bubbleSorted[i]);
        }
    }

    [Test]
    public void DoubleListWithSortByFractionIsSortedCorrectly()
    {
        var list = new List<double> { 3.2, 2.43, 6.03, 399.01, 0.7 };
        var bubbleSorted = BubbleSort.Sort(list, new Comparers.FractionComparer());
        var threshold = 1e-9;
        list.Sort(new Comparers.FractionComparer());
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(list[i], bubbleSorted[i], threshold);
        }
    }

    [Test]
    public void StringLinkedListWithSortByLengthIsSortedCorrectly()
    {
        var linkedList = new LinkedList<string>();
        linkedList.AddFirst("ew");
        linkedList.AddFirst("eweqw");
        linkedList.AddFirst("ke");
        linkedList.AddFirst("a");
        linkedList.AddFirst("ewerytry");
        var bubbleSorted = BubbleSort.Sort(linkedList, new Comparers.StringLengthComparer());
        var sorted = new List<string> { "a", "ke", "ew", "eweqw", "ewerytry" };
        int i = 0;
        foreach (var item in bubbleSorted)
        {
            Assert.AreEqual(sorted[i], item);
            i++;
        }
    }

    [Test]
    public void IntDictionaryIsNotSorted()
    {
        var dictionary = new Dictionary<int, int> { { 2, 1 }, { 1, 2 }, { 3, 3 } };
        Assert.Throws<ArgumentException>(() => BubbleSort.Sort(dictionary, null));
    }
}