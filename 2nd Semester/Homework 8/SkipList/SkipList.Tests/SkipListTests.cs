namespace SkipList.Tests;

using NUnit.Framework;

public class SkipListTests
{
    private SkipList<int> skipList = new ();

    [SetUp]
    public void Setup()
    {
        skipList = new SkipList<int>();
    }

    [Test]
    public void Add()
    {
        skipList.Add(1);
        skipList.Add(2);
        if (skipList.MaxLevel == 2)
        {

        }
    }
}