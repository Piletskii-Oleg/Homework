namespace StackCalculator;

/// <summary>
/// Calculator using reverse Polish notation.
/// </summary>
public class StackCalculator
{
    /// <summary>
    /// Gets or sets the stack used.
    /// </summary>
    public IStack Stack { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackCalculator"/> class.
    /// </summary>
    /// <param name="stack">Type of stack used.</param>
    public StackCalculator(IStack stack)
    {
        Stack = stack;
    }

    /// <summary>
    /// Calculates the value from the input.
    /// </summary>
    /// <param name="input">An expression to calculate.</param>
    /// <returns>Calculated value.</returns>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    public double? Evaluate(string input)
    {
        string[] array = input.Split(' ');
        double currentNumber;
        foreach (string item in array)
        {
            if (double.TryParse(item, out currentNumber))
            {
                Stack.Push(currentNumber);
            }
            else
            {
                switch (item)
                {
                    case "*":
                    case "+":
                    case "-":
                    case "/":
                        var firstOperand = Stack.Pop();
                        if (firstOperand == null)
                        {
                            return null;
                        }

                        var secondOperand = Stack.Pop();
                        if (secondOperand == null)
                        {
                            return null;
                        }

                        switch (item)
                        {
                            case "*":
                                Stack.Push((double)firstOperand * (double)secondOperand);
                                break;
                            case "+":
                                Stack.Push((double)firstOperand + (double)secondOperand);
                                break;
                            case "-":
                                Stack.Push((double)secondOperand - (double)firstOperand);
                                break;
                            case "/":
                                if (firstOperand.Equals(0.0))
                                {
                                    throw new DivideByZeroException("Division by zero");
                                }
                                Stack.Push((double)secondOperand / (double)firstOperand);
                                break;
                        }
                        break;

                    default:
                        return null;
                        break;
                }
            }
        }

        double? result = Stack.Pop();
        return Stack.IsEmpty() ? result : null;
    }
}

