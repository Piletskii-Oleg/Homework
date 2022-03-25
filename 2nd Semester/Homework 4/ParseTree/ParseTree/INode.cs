namespace ParseTree;

/// <summary>
/// An interface representing a node of a parse tree.
/// </summary>
public interface INode
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
    /// Calculates value of a node.
    /// </summary>
    /// <returns>Calculated value.</returns>
    public double Evaluate();

    /// <summary>
    /// Prints a node to the screen in the form of an arithmetic expression.
    /// </summary>
    public void Print();
}