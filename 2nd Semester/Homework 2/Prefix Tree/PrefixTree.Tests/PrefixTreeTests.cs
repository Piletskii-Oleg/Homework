namespace PrefixTree.Tests;

using NUnit.Framework;

public class Tests
{
    private Trie trie = new();

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [Test]
    public void AddReturnsTrueAndThenFalseIfInputsRepeat()
    {
        Assert.IsTrue(trie.Add("ber"));
        Assert.IsFalse(trie.Add("ber"));
    }

    [Test]
    public void SizeReturnsActualValueIfInputsRepeat()
    {
        trie.Add("ber");
        trie.Add("ber");
        trie.Add("jejr");
        trie.Add("jejk");
        Assert.AreEqual(3, trie.Size);
    }

    [Test]
    public void RemoveWorksAndDecreasesSize()
    {
        trie.Add("ber");
        trie.Add("rei");
        Assert.IsTrue(trie.Remove("ber"));
        Assert.AreEqual(1, trie.Size);
    }

    [Test]
    public void RemoveDoesNotWorkTwiceOnTheSameInput()
    {
        trie.Add("ber");
        Assert.IsTrue(trie.Remove("ber"));
        Assert.IsFalse(trie.Remove("ber"));
    }

    [Test]
    public void ContainsWorksProperly()
    {
        trie.Add("bobe");
        trie.Add("gaia");
        trie.Add("gaio");
        Assert.IsTrue(trie.Contains("bobe"));
        Assert.IsTrue(trie.Contains("gaia"));
        Assert.IsTrue(trie.Contains("gaio"));
    }

    [Test]
    public void WordIsNotRemovedIfItIsAPrefix()
    {
        trie.Add("bebe");
        trie.Remove("ber");
        Assert.IsTrue(trie.Contains("bebe"));
    }

    [Test]
    public void PrefixOfTheWordIsNotRemoved()
    {
        trie.Add("ber");
        trie.Add("berk");
        trie.Remove("berk");
        Assert.IsTrue(trie.Contains("ber"));
        Assert.IsFalse(trie.Contains("berk"));
    }

    [Test]
    public void TrieCanContainSingleLetterWords()
    {
        trie.Add("e");
        trie.Add("a");
        Assert.IsTrue(trie.Contains("e"));
        Assert.IsTrue(trie.Contains("a"));
        Assert.AreEqual(2, trie.Size);
    }

    [Test]
    public void TwoConsecutiveRemovesWithSuffixesWork()
    {
        trie.Add("ber");
        trie.Add("berk");
        Assert.IsTrue(trie.Remove("berk"));
        Assert.IsTrue(trie.Remove("ber"));
        Assert.IsFalse(trie.Contains("berk"));
        Assert.IsFalse(trie.Contains("ber"));
        Assert.AreEqual(0, trie.Size);
    }

    [Test]
    public void HowManyStartsWithPrefixWorksRight()
    {
        trie.Add("ber");
        trie.Add("berk");
        Assert.AreEqual(2, trie.HowManyStartsWithPrefix("be"));
        Assert.AreEqual(2, trie.HowManyStartsWithPrefix("ber"));
        Assert.AreEqual(1, trie.HowManyStartsWithPrefix("berk"));
    }

    [Test]
    public void HowManyStartsWithPrefixWorksRightAfterRemoval()
    {
        trie.Add("ber");
        trie.Add("bear");
        trie.Add("berk");
        trie.Remove("berk");
        Assert.AreEqual(2, trie.HowManyStartsWithPrefix("be"));
        trie.Remove("bear");
        Assert.AreEqual(1, trie.HowManyStartsWithPrefix("be"));
    }
}