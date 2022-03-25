namespace ParseTree;

/// <summary>
/// Node that stores a sum operator.
/// </summary>
public class OperatorAdd : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorAdd"/> class.
    /// </summary>
    public OperatorAdd()
        : base()
    {
        Operation = '+';
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorAdd"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    public OperatorAdd(INode parent)
        : base(parent)
    {
        Operation = '+';
    }

    /// <summary>
    /// Adds the values stored in children of a node.
    /// </summary>
    /// <returns>Sum of values of the left and right children.</returns>
    public override double Evaluate()
        => LeftChild.Evaluate() + RightChild.Evaluate();
}