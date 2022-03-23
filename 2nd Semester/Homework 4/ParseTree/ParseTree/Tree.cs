namespace ParseTree;

public class Node
{
    public double Value { get; set; }
    public char? Operation { get; set; }
    public Node? LeftChild { get; set; }
    public Node? RightChild { get; set; }
    public Node? Parent { get; set; }

    public Node()
    {
        LeftChild = null;
        RightChild = null;
    }
    public Node(Node parent)
        : this()
    {
        this.Parent = parent;
    }
    public Node(Node parent, double value)
        : this(parent)
    {
        this.Value = value;
        this.Operation = null;
    }
    public Node(Node parent, char operation)
        : this(parent)
    {
        this.Operation = operation;
    }

}

public class Tree
{
    public static Node CreateTree(string input)
    {
        string[] array = ParseInput(input);
        Node? currentElement = null;
        foreach (string item in array)
        {
            switch (item)
            {
                case "(":
                case " ":
                    continue;
                case "+":
                case "-":
                case "*":
                case "/":
                    var operandNode = new Node(currentElement, char.Parse(item));
                    if (currentElement == null)
                    {
                        currentElement = operandNode;
                    }
                    else if (currentElement.LeftChild == null)
                    {
                        currentElement.LeftChild = operandNode;
                        currentElement = currentElement.LeftChild;
                    }
                    else if (currentElement.RightChild == null)
                    {
                        currentElement.RightChild = operandNode;
                        currentElement = currentElement.RightChild;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
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
                        var numberNode = new Node(currentElement, number);
                        if (currentElement.LeftChild == null)
                        {
                            currentElement.LeftChild = numberNode;
                        }
                        else if (currentElement.RightChild == null)
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
        }

        while (currentElement.Parent != null)
            currentElement = currentElement.Parent;
        return currentElement;
    }

    public static double CalculateValue(Node root)
    {
        if (root.LeftChild == null && root.RightChild == null)
        {
            return root.Value;
        }
        double firstOperand = CalculateValue(root.LeftChild);
        double secondOperand = CalculateValue(root.RightChild);
        double result = 0;
        switch (root.Operation)
        {
            case '*':
                result = firstOperand * secondOperand;
                break;
            case '+':
                result = firstOperand + secondOperand;
                break;
            case '-':
                result = firstOperand - secondOperand;
                break;
            case '/':
                if (secondOperand.Equals(0.0))
                {
                    throw new DivideByZeroException();
                }
                result = firstOperand / secondOperand;
                break;
        }
        return result;
    }

    public static void PrintTree(Node root)
    {
        //if (root is Operator)
        //{
        //    root.Print();
        //}
        if (root.Operation != null)
        {
            Console.Write($"( {root.Operation} ");
        }
        else
        {
            Console.Write($"{root.Value} ");
            var currentNode = root;
            while (currentNode.Parent != null && currentNode.Parent.RightChild == currentNode)
            {
                Console.Write(") ");
                currentNode = currentNode.Parent;
            }
        }
        PrintTree(root.LeftChild);
        PrintTree(root.RightChild);
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

