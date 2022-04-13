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
        Assert.AreEqual(trie.Size, 3);
    }

    [Test]
    public void RemoveWorksAndDecreasesSize()
    {
        trie.Add("ber");
        trie.Add("rei");
        Assert.IsTrue(trie.Remove("ber"));
        Assert.AreEqual(trie.Size, 1);
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
        trie.Add("beb");
        trie.Add("bebe");
        trie.Remove("bebe");
        Assert.IsTrue(trie.Contains("beb"));
    }

    [Test]
    public void TrieCanContainSingleLetterWords()
    {
        trie.Add("e");
        trie.Add("a");
        Assert.IsTrue(trie.Contains("e"));
        Assert.IsTrue(trie.Contains("a"));
        Assert.AreEqual(trie.Size, 2);
    }

    [Test]
    public void TwoConsecutiveRemovesWithSuffixesWork()
    {
        trie.Add("ber");
        trie.Add("berk");
        Assert.IsTrue(trie.Remove("berk"));
        Assert.IsTrue(trie.Remove("ber"));
    }

    [Test]
    public void HowManyStartsWithPrefixWorksRight()
    {
        trie.Add("ber");
        trie.Add("berk");
        Assert.AreEqual(trie.HowManyStartsWithPrefix("be"), 2);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("ber"), 2);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("berk"), 1);
    }

    [Test]
    public void HowManyStartsWithPrefixWorksRightAfterRemoval()
    {
        trie.Add("ber");
        trie.Add("bear");
        trie.Add("berk");
        trie.Remove("berk");
        Assert.AreEqual(trie.HowManyStartsWithPrefix("be"), 2);
        trie.Remove("bear");
        Assert.AreEqual(trie.HowManyStartsWithPrefix("be"), 1);
    }
}