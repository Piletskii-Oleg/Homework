namespace ParseTree;

internal class OperatorMultiply : Operator
{
    public override double Evaluate()
    {
        return LeftChild.Evaluate() * RightChild.Evaluate();
    }
}