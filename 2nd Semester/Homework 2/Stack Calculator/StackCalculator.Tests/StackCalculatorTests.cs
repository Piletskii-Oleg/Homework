using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace StackCalculator.Tests;

public class Tests
{
    private static IEnumerable<TestCaseData> Stacks
        => new []
        {
        new TestCaseData(new ArrayStack()),
        new TestCaseData(new ListStack()),
        };
    
    [Test, TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldWorkOnCorrectInput(IStack stack)
    {
        Assert.AreEqual(StackCalculator.Evaluate("2 3 + 1 - 9 *", stack), 36.0);
        Assert.AreEqual(StackCalculator.Evaluate("1000 2 * 90 -", stack), 1910.0);
        Assert.AreEqual(StackCalculator.Evaluate("90 5 / 3 /", stack), 6.0);
        Assert.AreEqual(StackCalculator.Evaluate("64 2 * 2 /", stack), 64.0);
    }

    [Test, TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldNotWorkOnIncorrectInput(IStack stack)
    {
        Assert.IsNull(StackCalculator.Evaluate("2 3 - - - 9", stack));
        Assert.IsNull(StackCalculator.Evaluate("2 3 3 3 7 - - 9 *", stack));
        Assert.IsNull(StackCalculator.Evaluate("a d 3 3 +", stack));
        Assert.IsNull(StackCalculator.Evaluate("2 3+ 3 -", stack));
    }

    [Test, TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldThrowExceptionWhenDividingByZero(IStack stack)
    {
        Assert.Throws<DivideByZeroException>(
            () => StackCalculator.Evaluate("9 0 /", stack));
    }

    [Test, TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldWorkWithNegativeNumbers(IStack stack)
    {
        Assert.AreEqual(StackCalculator.Evaluate("-3 -6 + 9 * -9 /", stack), 9.0);
        Assert.AreEqual(StackCalculator.Evaluate("-253 253 + 9 / 9 *", stack), 0.0);
    }
}
