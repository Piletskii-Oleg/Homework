namespace SparseVector.Tests;

using NUnit.Framework;
using System;
using System.Collections.Generic;

public class Tests
{
    [Test]
    public void TwoVectorsOfLengthThreeShouldAdd()
    {
        var vector = new Vector(new [] { 1, 2, 3 });
        var vector2 = new Vector(new [] { -1, 0, 6 });
        vector.Add(vector2);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(2, vector.Count);
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(9, vector[2]);
        });
    }

    [Test]
    public void VectorShouldNotContainZeroValuesWhenDeclared()
    {
        var vector = new Vector(new [] { 1, 2, 0, 0, 3, 0 });
        Assert.Multiple(() =>
        {
            Assert.AreEqual(3, vector.Count);
            Assert.AreEqual(3, vector[4]);
        });
    }

    [Test]
    public void VectorsOfDifferentLengthCannotBeAddedWhenDeclaredWithCapacity()
    {
        var vector = new Vector(3);
        var vector2 = new Vector(4);
        Assert.Throws<ArgumentException>(() => vector.Add(vector2));
    }

    [Test]
    public void VectorsOfDifferentLengthCannotBeAddedWhenDeclaredWithArrays()
    {
        var vector = new Vector(new [] { 2, 3, 4 });
        var vector2 = new Vector(new [] { 7 });
        Assert.Throws<ArgumentException>(() => vector.Add(vector2));
    }
    
    [Test]
    public void VectorsOfDifferentLengthCannotBeAddedWhenDeclaredWithLists()
    {
        var vector = new Vector(new List<int> { 2, 3, 4 });
        var vector2 = new Vector(new List<int> { 7 });
        Assert.Throws<ArgumentException>(() => vector.Add(vector2));
    }

    [Test]
    public void VectorsShouldBeAbleToBeAddedWhenOneOfTheValuesBecomesZeroThenNonZeroAgain()
    {
        var vector = new Vector(new [] { 2, 3, 4 });
        var vector1 = new Vector(new [] { 3, -3, 4 });
        var vector2 = new Vector(new [] { 3, 4, 1 });
        vector.Add(vector1);
        Assert.DoesNotThrow(() => vector.Add(vector2));
        Assert.AreEqual(4, vector[1]);
    }

    [Test]
    public void TwoVectorsCanBeSubtracted()
    {
        var vector = new Vector(new [] { 1, 0, 3, 5 });
        var vector2 = new Vector(new [] { 9, 0, -3, -5 });
        vector.Subtract(vector2);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(3, vector.Count);
            Assert.AreEqual(-8, vector[0]);
            Assert.AreEqual(6, vector[2]);
            Assert.AreEqual(10, vector[3]);
        });
    }

    [Test]
    public void TwoVectorsCanBeSubtractedIfSomeValuesInFirstAreZero()
    {
        var vector = new Vector(new [] { 1, 0, 0, 0 });
        var vector2 = new Vector(new [] { 9, 0, -3, -5 });
        Assert.DoesNotThrow(() => vector.Subtract(vector2));
    }

    [Test]
    public void DotProductIsCalculatedCorrectly()
    {
        var vector = new Vector(new [] { 2, 3, 4 });
        var vector2 = new Vector(new [] { 2, 3, 4 });
        Assert.AreEqual(29, Vector.DotProduct(vector2, vector));
    }

    [Test]
    public void DotProductIsCalculatedWhenSomeValuesAreZeroInOneVector()
    {
        var vector = new Vector(new [] { 2, 0, 3 });
        var vector2 = new Vector(new [] { 3, 4, 9 });
        Assert.AreEqual(33, Vector.DotProduct(vector, vector2));
    }

    [Test]
    public void DotProductIsCalculatedWhenSomeValuesAreZeroInBothVectors()
    {
        var vector = new Vector(new [] { 2, 0, 3, 8, 0 });
        var vector2 = new Vector(new [] { 3, 4, 9, 0, 1 });
        Assert.AreEqual(33, Vector.DotProduct(vector, vector2));
    }

    [Test]
    public void VectorDeclaredWithCapacityShouldBeNull()
    {
        var vector = new Vector(3);
        Assert.IsTrue(vector.IsNullVector());
        Assert.IsTrue(Vector.IsNullVector(vector));
    }

    [Test]
    public void VectorThatBecameEmptyAfterSumShouldBeNull()
    {
        var vector = new Vector(new [] { 3, 2 });
        vector.Add(new Vector(new [] { -3, -2 }));
        Assert.IsTrue(vector.IsNullVector());
        Assert.IsTrue(Vector.IsNullVector(vector));
    }

    [Test]
    public void VectorCopiedWithConstructorShouldBeSame()
    {
        var vector = new Vector(new [] { 2, 3 });
        var copy = new Vector(vector);
        Assert.Multiple(() =>
        {
            Assert.IsFalse(vector.Equals(copy));
            Assert.AreEqual(vector.Capacity, copy.Capacity);
            Assert.AreEqual(vector.Count, copy.Count);
            Assert.AreEqual(2, copy[0]);
            Assert.AreEqual(3, copy[1]);
        });
    }
}