using NUnit.Framework;

namespace Routers.Tests;

public class DisjointSetTests
{
    private SetElement firstElement = new ();
    private SetElement secondElement = new ();
    private SetElement thirdElement = new ();

    [SetUp]
    public void Setup()
    {
        firstElement = new SetElement();
        secondElement = new SetElement();
        thirdElement = new SetElement();
    }

    [Test]
    public void TwoElementsCanBeUnited()
    {
        DisjointSet.Union(firstElement, secondElement);
        Assert.Multiple(() =>
        {
            Assert.IsTrue(firstElement.Identificator.Equals(firstElement));
            Assert.IsTrue(secondElement.Identificator.Equals(firstElement));
            Assert.AreEqual(1, firstElement.Rank);
            Assert.AreEqual(0, secondElement.Rank);
        });
    }

    [Test]
    public void FindWorksCorrectlyIfTwoElementsAreUnited()
    {
        DisjointSet.Union(firstElement, secondElement);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(firstElement, DisjointSet.Find(firstElement));
            Assert.AreEqual(firstElement, DisjointSet.Find(secondElement));
        });
    }

    [Test]
    public void SmallerSetGetsInBiggerSet()
    {
        DisjointSet.Union(firstElement, secondElement);
        DisjointSet.Union(firstElement, thirdElement);
        Assert.Multiple(() =>
        {
            Assert.AreEqual(firstElement, thirdElement.Identificator);
            Assert.AreEqual(1, firstElement.Rank);
            Assert.AreEqual(0, secondElement.Rank);
            Assert.AreEqual(0, thirdElement.Rank);
        });
    }
}