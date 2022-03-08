using NUnit.Framework;
using StackCalculator;

using System.Collections.Generic;

namespace Stack.Tests;

public class Tests
{
    private static IEnumerable<IStack> stacks
    {
        get
        {
            yield return new ArrayStack();
            yield return new ListStack();
        }
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void PushShouldWork(IStack stack)
    {
        stack.Push(1.6);
        Assert.IsFalse(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void PopShouldReturnSameResultAsPush(IStack stack)
    {
        stack.Push(8.1);
        Assert.AreEqual(stack.Pop(), 8.1);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void ResultsAfterPushesAndPopsShouldBeCorrect(IStack stack)
    {
        stack.Push(8.1);
        stack.Push(1.1);
        stack.Push(10);
        Assert.AreEqual(stack.Pop(), 10);
        Assert.AreEqual(stack.Pop(), 1.1);
        Assert.AreEqual(stack.Pop(), 8.1);
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void StackShouldNotBeEmptyAfterPush(IStack stack)
    {
        stack.Push(1.2);
        Assert.IsFalse(stack.IsEmpty());
    }

    [Test, TestCaseSource(nameof(stacks))]
    public void StackShouldBeEmptyAfterPop(IStack stack)
    {
        stack.Push(1.3);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }
}
