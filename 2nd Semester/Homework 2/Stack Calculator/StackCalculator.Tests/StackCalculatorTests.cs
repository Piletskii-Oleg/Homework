namespace StackCalculator.Tests;

using NUnit.Framework;
using System;
using StackCalculator.Exceptions;
using System.Collections.Generic;

public class StackCalculatorTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new []
        {
            new TestCaseData(new ArrayStack()),
            new TestCaseData(new ListStack()),
        };
    
    [TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldWorkOnCorrectInput(IStack stack)
    {
        Assert.AreEqual(36.0, Calculator.Evaluate("2 3 + 1 - 9 *", stack));
        Assert.AreEqual(1910.0, Calculator.Evaluate("1000 2 * 90 -", stack));
        Assert.AreEqual(6.0,Calculator.Evaluate("90 5 / 3 /", stack));
        Assert.AreEqual(64.0, Calculator.Evaluate("64 2 * 2 /", stack));
    }

    [Test, TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldNotWorkOnIncorrectInput(IStack stack)
    {
        Assert.Throws<PopFromEmptyStackException>(() => Calculator.Evaluate("2 3 - - - 9", stack));
        Assert.Throws<IncorrectExpressionException>(() => Calculator.Evaluate("2 3 3 3 7 - - 9 *", stack));
        Assert.Throws<IncorrectExpressionException>(() => Calculator.Evaluate("a d 3 3 +", stack));
        Assert.Throws<IncorrectExpressionException>(() => Calculator.Evaluate("2 3+ 3 -", stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldThrowExceptionWhenDividingByZero(IStack stack)
    {
        Assert.Throws<DivideByZeroException>(
            () => Calculator.Evaluate("9 0 /", stack));
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculatorShouldWorkWithNegativeNumbers(IStack stack)
    {
        Assert.AreEqual(Calculator.Evaluate("-3 -6 + 9 * -9 /", stack), 9.0);
        Assert.AreEqual(Calculator.Evaluate("-253 253 + 9 / 9 *", stack), 0.0);
    }
}
