namespace ParseTree;

internal class OperatorSubtract : Operator
{
    public override double Evaluate()
    {
        return LeftChild.Evaluate() - RightChild.Evaluate();
    }
}