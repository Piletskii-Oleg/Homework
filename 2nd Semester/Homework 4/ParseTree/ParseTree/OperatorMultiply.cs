namespace ParseTree;

public class OperatorMultiply : Operator
{
    public OperatorMultiply(INode parent, char operation) 
        : base(parent, operation) { }

    public override double Evaluate()
        => LeftChild.Evaluate() * RightChild.Evaluate();
}