namespace ParseTree;

/// <summary>
/// 
/// </summary>
public class Tree
{
    public static INode CreateTree(string input)
    {
        string[] array = ParseInput(input);
        INode? currentElement = null;
        Operator? operandNode = null;
        foreach (string item in array)
        {
            switch (item)
            {
                case "(":
                case " ":
                    continue;
                case "+":
                    operandNode = new OperatorAdd(currentElement, char.Parse(item));
                    break;
                case "-":
                    operandNode = new OperatorSubtract(currentElement, char.Parse(item));
                    break;
                case "*":
                    operandNode = new OperatorMultiply(currentElement, char.Parse(item));
                    break;
                case "/":
                    operandNode = new OperatorDivide(currentElement, char.Parse(item));
                    break;
                case ")":
                    if (currentElement.Parent != null)
                    {
                        currentElement = currentElement.Parent;
                    }

                    break;
                default:
                    int number;
                    if (int.TryParse(item, out number))
                    {
                        var numberNode = new Operand(currentElement, number);
                        if (currentElement.LeftChild is null)
                        {
                            currentElement.LeftChild = numberNode;
                        }
                        else if (currentElement.RightChild is null)
                        {
                            currentElement.RightChild = numberNode;
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }

                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
            }

            switch (item)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    if (currentElement is null)
                    {
                        currentElement = operandNode;
                    }
                    else if (currentElement.LeftChild is null)
                    {
                        currentElement.LeftChild = operandNode;
                        currentElement = currentElement.LeftChild;
                    }
                    else if (currentElement.RightChild is null)
                    {
                        currentElement.RightChild = operandNode;
                        currentElement = currentElement.RightChild;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                    break;
                default:
                    break;
            }
        }

        while (currentElement.Parent != null)
            currentElement = currentElement.Parent;
        return currentElement;
    }

    public static double CalculateValue(INode root)
        => root.Evaluate();

    public static void PrintTree(INode root)
    {
        root.Print();
        if (root.LeftChild is not null)
        {
            PrintTree(root.LeftChild);
        }

        if (root.RightChild is not null)
        {
            PrintTree(root.RightChild);
        }
    }

    private static string[] ParseInput(string input)
    {
        List<string> parsed = input.Split(' ').ToList();
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
                    int number;
                    if (int.TryParse(parsed[i], out number))
                    {
                        continue;
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