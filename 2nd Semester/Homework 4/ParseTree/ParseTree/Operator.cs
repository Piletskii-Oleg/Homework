namespace ParseTree;

/// <summary>
/// Node that stores an operator.
/// </summary>
public abstract class Operator : INode
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
    /// Gets or sets an arithmetic operation.
    /// </summary>
    public char Operation { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Operator"/> class.
    /// </summary>
    protected Operator()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Operator"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    protected Operator(INode parent)
        : this()
    {
        Parent = parent;
    }

    /// <summary>
    /// Calculates the value of the node according to the stored operation.
    /// </summary>
    /// <returns>Calculated value.</returns>
    public abstract double Evaluate();

    /// <summary>
    /// Prints stored operation on the screen.
    /// </summary>
    public void Print()
        => Console.Write($"( {Operation} ");
}