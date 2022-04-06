namespace StackCalculator;

/// <summary>
/// Calculator implemented using reverse Polish notation.
/// </summary>
public static class StackCalculator
{
    /// <summary>
    /// Calculates the value from the input.
    /// </summary>
    /// <param name="input">An expression to calculate.</param>
    /// <param name="stack">Stack implementation.</param>
    /// <returns>Calculated value.</returns>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    public static double? Evaluate(string input, IStack stack)
    {
        string[] array = input.Split(' ');
        double threshold = 0.0000001;
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
                        if (firstOperand == null)
                        {
                            return null;
                        }

                        var secondOperand = stack.Pop();
                        if (secondOperand == null)
                        {
                            return null;
                        }

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
                                if (firstOperand < threshold)
                                {
                                    throw new DivideByZeroException();
                                }

                                stack.Push((double)secondOperand / (double)firstOperand);
                                break;
                            default:
                                return null;
                        }

                        break;

                    default:
                        return null;
                }
            }
        }

        double? result = stack.Pop();
        return stack.IsEmpty() ? result : null;
    }
}