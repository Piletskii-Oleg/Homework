namespace ParseTree;

/// <summary>
/// Node that stores a real value.
/// </summary>
public class Operand : INode
{
    /// <summary>
    /// Gets or sets left child of a node.
    /// </summary>
    public INode? LeftChild { get; set; }

    /// <summary>
    /// Gets or sets right child of a node.
    /// </summary>
    public INode? RightChild { get; set; }

    /// <summary>
    /// Gets or sets parent of a node.
    /// </summary>
    public INode? Parent { get; set; }

    /// <summary>
    /// Gets or sets a real value.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Operand"/> class.
    /// </summary>
    /// <param name="value">A real value.</param>
    public Operand(double value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Operand"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    /// <param name="value">A real value.</param>
    public Operand(INode parent, double value)
        : this(value)
    {
        Parent = parent;
    }

    /// <summary>
    /// Returns a real value stored in the node.
    /// </summary>
    /// <returns>A real value.</returns>
    public double Evaluate()
        => Value;

    /// <summary>
    /// Prints the value on the screen.
    /// </summary>
    public void Print()
    {
        Console.Write($"{Value} ");
        INode currentNode = this;
        while (currentNode.Parent is not null && currentNode.Parent.RightChild == currentNode)
        {
            Console.Write($") ");
            currentNode = currentNode.Parent;
        }
    }
}