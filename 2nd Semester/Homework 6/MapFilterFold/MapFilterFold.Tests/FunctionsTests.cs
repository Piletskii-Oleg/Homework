namespace MapFilterFold.Tests;

using MapFilterFold;
using NUnit.Framework;
using System.Collections.Generic;

public class Tests
{
    [Test]
    public void MapShouldWorkWithSameTypes()
    {
        var list = Functions<int>.Map(new List<int> { 2, 8, 11 }, x => x * x);
        Assert.AreEqual(new List<int> { 4, 64, 121 }, list);
    }

    [Test]
    public void MapShouldBeAbleToChangeTypes()
    {
        var list = Functions<int>.Map(new List<int> { 3, 1, 2 }, x => x.ToString());
        Assert.AreEqual(new List<string> { "3", "1", "2" }, list);
    }

    [Test]
    public void FilterShouldWorkCorrectly()
    {
        var list = Functions<int>.Filter(new List<int> { 9123, 231, 392, 11 }, x => x % 2 == 0);
        Assert.AreEqual(new List<int> { 392 }, list);
    }

    [Test]
    public void FoldShouldWorkCorrectlyWithDifferentTypes()
    {
        var result = Functions<int>.Fold(new List<int> { 2, 4, 9 }, "22", (acc, param) => acc + param);
        Assert.AreEqual("22249", result);
    }

    [Test]
    public void FoldShouldWorkCorrectlyWithSameTypes()
    {
        var result = Functions<int>.Fold(new List<int> { 32, 3, 11}, 1, (acc, param) => acc * acc + param);
        Assert.AreEqual(1192475, result);
    }
}