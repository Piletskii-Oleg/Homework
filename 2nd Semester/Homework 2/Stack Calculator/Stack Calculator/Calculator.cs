namespace StackCalculator;

using StackCalculator.Exceptions;

/// <summary>
/// Calculator implemented using reverse Polish notation.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Calculates the value from the input.
    /// </summary>
    /// <param name="input">An expression to calculate.</param>
    /// <param name="stack">Stack implementation.</param>
    /// <returns>Calculated value.</returns>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    public static double Evaluate(string input, IStack stack)
    {
        string[] array = input.Split(' ');
        decimal threshold = 1E-9M;
        foreach (string item in array)
        {
            if (double.TryParse(item, out double currentNumber))
            {
                stack.Push(currentNumber);
            }
            else
            {
                switch (item)
                {
                    case "*":
                    case "+":
                    case "-":
                    case "/":
                        var firstOperand = stack.Pop();
                        var secondOperand = stack.Pop();

                        switch (item)
                        {
                            case "*":
                                stack.Push((double)firstOperand * (double)secondOperand);
                                break;
                            case "+":
                                stack.Push((double)firstOperand + (double)secondOperand);
                                break;
                            case "-":
                                stack.Push((double)secondOperand - (double)firstOperand);
                                break;
                            case "/":
                                if (Math.Abs((decimal)firstOperand) < threshold)
                                {
                                    throw new DivideByZeroException();
                                }

                                stack.Push((double)secondOperand / (double)firstOperand);
                                break;
                            default:
                                throw new IncorrectExpressionException();
                        }

                        break;
                    default:
                        throw new IncorrectExpressionException();
                }
            }
        }

        double result = stack.Pop();
        if (stack.IsEmpty())
        {
            return result;
        }

        throw new IncorrectExpressionException();
    }
}