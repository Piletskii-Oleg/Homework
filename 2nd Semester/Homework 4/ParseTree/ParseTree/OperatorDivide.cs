namespace ParseTree;

internal class OperatorDivide : Operator
{
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