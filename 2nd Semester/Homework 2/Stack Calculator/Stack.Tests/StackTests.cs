using NUnit.Framework;
using StackCalculator;

namespace Stack.Tests;

public class Tests
{
    private ArrayStack arrayStack = new ArrayStack(10);
    private ListStack listStack = new ListStack();

    [SetUp]
    public void Setup()
    {
        var arrayStack = new ArrayStack(10);
        var listStack = new ListStack();
    }

    [Test]
    public void PushShouldWork()
    {
        arrayStack.Push(1.6);
        listStack.Push(1.6);
        Assert.IsFalse(listStack.IsEmpty());
        Assert.IsTrue(arrayStack.IsEmpty());
    }

    [Test]
    public void ResultsAfterPushesAndPopsShouldBeUhhhhhhhhhhhhhhhhh()
    {
        
    }
}
