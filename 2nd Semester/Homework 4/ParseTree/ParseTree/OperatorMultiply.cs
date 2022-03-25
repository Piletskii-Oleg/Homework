namespace ParseTree;

/// <summary>
/// Node that stores a multiplication operator.
/// </summary>
public class OperatorMultiply : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorMultiply"/> class.
    /// </summary>
    public OperatorMultiply()
        : base()
    {
        Operation = '*';
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorMultiply"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    public OperatorMultiply(INode parent)
        : base(parent)
    {
        Operation = '*';
    }

    /// <summary>
    /// Multiplies the values stored in children of a node.
    /// </summary>
    /// <returns>Product of values of left and right children.</returns>
    public override double Evaluate()
        => LeftChild.Evaluate() * RightChild.Evaluate();
}