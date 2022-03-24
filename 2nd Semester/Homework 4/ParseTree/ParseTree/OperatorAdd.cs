namespace ParseTree;

public class OperatorAdd : Operator
{
    public OperatorAdd(INode parent, char operation) 
        : base(parent, operation) { }

    public override double Evaluate()
        => LeftChild.Evaluate() + RightChild.Evaluate();
}