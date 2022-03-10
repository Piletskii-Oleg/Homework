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
        double currentNumber;
        foreach (string item in array)
        {
            if (double.TryParse(item, out currentNumber))
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
                                if (firstOperand.Equals(0.0))
                                {
                                    throw new DivideByZeroException();
                                }
                                stack.Push((double)secondOperand / (double)firstOperand);
                                break;
                        }
                        break;

                    default:
                        return null;
                        break;
                }
            }
        }

        double? result = stack.Pop();
        return stack.IsEmpty() ? result : null;
    }
}