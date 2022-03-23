namespace ParseTree;

internal class OperatorAdd : Operator
{
    public override double Evaluate()
    {
        return LeftChild.Evaluate() + RightChild.Evaluate();
    }
}