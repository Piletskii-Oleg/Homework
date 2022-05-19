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
        BubbleSort.Sort(array, null);
        var sorted = new[] { 3, 9, 33, 123, 586 };
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(array[i], sorted[i]);
        }
    }

    [Test]
    public void IntArrayWithReverseComparerIsSortedCorrectly()
    {
        var array = new[] { 3, 9, 123, 586, 33 };
        BubbleSort.Sort(array, new ReverseComparer());
        var sorted = new[] { 586, 123, 33, 9, 3 };
        for (int i = 0; i < array.Length; i++)
        {
            Assert.AreEqual(array[i], sorted[i]);
        }
    }

    [Test]
    public void DoubleListWithSortByFractionIsSortedCorrectly()
    {
        var list = new List<double> { 3.2, 2.43, 6.03, 399.01, 0.7 };
        BubbleSort.Sort(list, new FractionComparer());
        var threshold = 1e-9;
        var sorted = new[] { 399.01, 6.03, 3.2, 2.43, 0.7 };
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(list[i], sorted[i], threshold);
        }
    }

    [Test]
    public void StringListWithSortByLengthIsSortedCorrectly()
    {
        var list = new List<string> { "eqw", "23e", "s" , "eeeee", "eksl" };
        BubbleSort.Sort(list, new StringLengthComparer());
        var sorted = new List<string> { "s", "eqw", "23e", "eksl", "eeeee" };
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(list[i], sorted[i]);
        }
    }

    private class FractionComparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            var fractionX = x - Math.Truncate(x);
            var fractionY = y - Math.Truncate(y);
            double threshold = 1e-9;
            if (fractionX > fractionY)
            {
                return 1;
            }
            else if (Math.Abs(fractionX - fractionY) < threshold)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    private class ReverseComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
            {
                return -1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    private class StringLengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x is null)
            {
                throw new ArgumentException("String cannot be null", x);
            }
            else if (y is null)
            {
                throw new ArgumentException("String cannot be null", y);
            }

            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x.Length == y.Length)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}