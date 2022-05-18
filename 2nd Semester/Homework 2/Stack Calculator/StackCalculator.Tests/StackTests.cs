namespace Stack.Tests;

using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;
using StackCalculator.Exceptions;
public class Tests
{
    private static IEnumerable<TestCaseData> Stacks
    => new[]
    {
        new TestCaseData(new ArrayStack()),
        new TestCaseData(new ListStack()),
    };

    [TestCaseSource(nameof(Stacks))]
    public void PushShouldWork(IStack stack)
    {
        stack.Push(1.6);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PopShouldReturnSameResultAsPush(IStack stack)
    {
        stack.Push(8.1);
        Assert.AreEqual(stack.Pop(), 8.1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void ResultsAfterPushesAndPopsShouldBeCorrect(IStack stack)
    {
        stack.Push(8.1);
        stack.Push(1.1);
        stack.Push(10);
        Assert.AreEqual(stack.Pop(), 10);
        Assert.AreEqual(stack.Pop(), 1.1);
        Assert.AreEqual(stack.Pop(), 8.1);
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldNotBeEmptyAfterPush(IStack stack)
    {
        stack.Push(1.2);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void StackShouldBeEmptyAfterPop(IStack stack)
    {
        stack.Push(1.3);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PopFromEmptyStackShouldThrowException(IStack stack)
    {
        Assert.Throws<PopFromEmptyStackException>(() => stack.Pop());
        stack.Push(1);
        stack.Pop();
        Assert.Throws<PopFromEmptyStackException>(() => stack.Pop());
    }
}
