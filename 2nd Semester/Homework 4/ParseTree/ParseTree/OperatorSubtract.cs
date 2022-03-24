namespace ParseTree;

public class OperatorSubtract : Operator
{
    public OperatorSubtract(INode parent, char operation)
        : base(parent, operation) { }

    public override double Evaluate()
        => LeftChild.Evaluate() - RightChild.Evaluate();
}