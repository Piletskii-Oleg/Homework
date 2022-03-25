namespace ParseTree;

/// <summary>
/// Node that stores a subtraction operator.
/// </summary>
public class OperatorSubtract : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorSubtract"/> class.
    /// </summary>
    public OperatorSubtract()
    {
        Operation = '-';
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorSubtract"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    public OperatorSubtract(INode parent)
        : base(parent)
    {
        Operation = '-';
    }

    /// <summary>
    /// Subtracts the values stored in children of a node.
    /// </summary>
    /// <returns>Difference of values of left (minuend) and right (subtrahend) children.</returns>
    public override double Evaluate()
        => LeftChild.Evaluate() - RightChild.Evaluate();
}