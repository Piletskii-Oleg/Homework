namespace ParseTree;

/// <summary>
/// Node that stores a division operator.
/// </summary>
public class OperatorDivide : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorDivide"/> class.
    /// </summary>
    public OperatorDivide()
    {
        Operation = '/';
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorDivide"/> class.
    /// </summary>
    /// <param name="parent">Parent of a node.</param>
    public OperatorDivide(INode parent)
        : base(parent)
    {
        Operation = '/';
    }

    /// <summary>
    /// Divides the values stored in children of a node.
    /// </summary>
    /// <returns>Quotient of values of the left (dividend) and right (divisor) children.</returns>
    /// <exception cref="DivideByZeroException">Throws if an attempt to divide by zero was made.</exception>
    public override double Evaluate()
    {
        double firstOperand = LeftChild.Evaluate();
        double secondOperand = RightChild.Evaluate();
        if (secondOperand.Equals(0.0))
        {
            throw new DivideByZeroException();
        }

        return firstOperand / secondOperand;
    }
}