namespace ParseTree;

/// <summary>
/// An ordered tree that represents the structure of an arithmetic expression.
/// </summary>
public static class Tree
{
    /// <summary>
    /// Creates a parse tree.
    /// </summary>
    /// <param name="input">An arithmetic expression.</param>
    /// <returns>Root of the created tree.</returns>
    /// <exception cref="InvalidOperationException">Throws if an unknown symbol is encountered.</exception>
    /// <exception cref="ArgumentException">Throws if the input string is not correct.</exception>
    public static INode? CreateTree(string input)
    {
        string[] array = ParseInput(input);
        INode? currentElement = null;
        Operator? operatorNode = null;
        foreach (string item in array)
        {
            switch (item)
            {
                case "(":
                case " ":
                    continue;
                case "+":
                    operatorNode = new OperatorAdd(currentElement);
                    operatorNode.AddNode(ref currentElement);
                    break;
                case "-":
                    operatorNode = new OperatorSubtract(currentElement);
                    operatorNode.AddNode(ref currentElement);
                    break;
                case "*":
                    operatorNode = new OperatorMultiply(currentElement);
                    operatorNode.AddNode(ref currentElement);
                    break;
                case "/":
                    operatorNode = new OperatorDivide(currentElement);
                    operatorNode.AddNode(ref currentElement);
                    break;
                case ")":
                    if (currentElement.Parent is not null)
                    {
                        currentElement = currentElement.Parent;
                    }

                    break;
                default:
                    if (int.TryParse(item, out int number))
                    {
                        var numberNode = new Operand(currentElement, number);
                        numberNode.AddNode(ref currentElement);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("The input string was not a correct expression");
                    }
            }
        }

        while (currentElement is not null && currentElement.Parent is not null)
        {
            currentElement = currentElement.Parent;
        }

        return currentElement;
    }

    /// <summary>
    /// Calculates an expression stored in the tree.
    /// </summary>
    /// <param name="root">Root of a parse tree.</param>
    /// <returns>Calculated value.</returns>
    public static double CalculateValue(INode root)
        => root.Evaluate();

    /// <summary>
    /// Prints the parse tree on screen in the form of an arithmetic expression.
    /// </summary>
    /// <param name="root">Root of a parse tree.</param>
    public static void PrintTree(INode root)
        => root.Print();

    private static string[] ParseInput(string input)
    {
        List<string> parsed = input.Split(' ').ToList();
        parsed.RemoveAll(x => x == string.Empty);
        for (int i = 0; i < parsed.Count; i++)
        {
            switch (parsed[i])
            {
                case "(":
                case " ":
                case "+":
                case "-":
                case "*":
                case "/":
                    continue;
                default:

                    if (int.TryParse(parsed[i], out _))
                    {
                        continue;
                    }
                    else if (parsed[i][parsed[i].Length - 1].Equals(')'))
                    {
                        int lastIndexOfBracket = parsed[i].IndexOf(')');
                        int pastLength = parsed[i].Length;
                        char[] tryNumber = new char[lastIndexOfBracket];
                        parsed[i].CopyTo(0, tryNumber, 0, lastIndexOfBracket);
                        if (int.TryParse(tryNumber, out _))
                        {
                            parsed.RemoveAt(i);
                            parsed.Insert(i, new string(tryNumber));
                            while (lastIndexOfBracket < pastLength)
                            {
                                parsed.Insert(i + 1, ")");
                                lastIndexOfBracket++;
                            }
                        }

                        break;
                    }
                    else
                    {
                        var newElements = new List<string>();
                        foreach (char c in parsed[i])
                        {
                            newElements.Add(c.ToString());
                        }

                        parsed.RemoveAt(i);
                        for (int j = 0; j < newElements.Count; j++)
                        {
                            parsed.Insert(i + j, newElements[j]);
                        }

                        break;
                    }
            }
        }

        return parsed.ToArray();
    }
}