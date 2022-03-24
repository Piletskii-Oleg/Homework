namespace ParseTree;

public class OperatorDivide : Operator
{
    public OperatorDivide(INode parent, char operation)
        : base(parent, operation) { }

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