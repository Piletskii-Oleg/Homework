using NUnit.Framework;
using System;

namespace StackCalculator.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CalculatorShouldWorkOnCorrectInput()
    {
        var stack = new ListStack();
        var calc = new StackCalculator(stack);
        Assert.AreEqual(calc.Evaluate("2 3 + 1 - 9 *"), 36.0);
        Assert.AreEqual(calc.Evaluate("1000 2 * 90 -"), 1910.0);
        Assert.AreEqual(calc.Evaluate("90 5 / 3 /"), 6.0);
        Assert.AreEqual(calc.Evaluate("64 2 * 2 /"), 64.0);
    }

    [Test]
    public void CalculatorShouldNotWorkOnIncorrectInput()
    {
        var stack = new ArrayStack(10);
        var calc = new StackCalculator(stack);
        Assert.IsNull(calc.Evaluate("2 3 - - - 9"));
        Assert.IsNull(calc.Evaluate("2 3 3 3 7 - - 9 *"));
        Assert.IsNull(calc.Evaluate("a d 3 3 +"));
    }

    [Test]
    public void CalculatorShouldNotDivideByZero()
    {
        var stack = new ArrayStack(10);
        var calc = new StackCalculator(stack);
        var exception = Assert.Throws<DivideByZeroException>(
            () => calc.Evaluate("9 0 /"));
        Assert.That(exception.Message, Is.EqualTo("Division by zero"));
    }
}
