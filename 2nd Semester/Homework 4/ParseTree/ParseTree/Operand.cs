namespace ParseTree;

public class Operand : INode
{
    public INode? LeftChild { get; set; }

    public INode? RightChild { get; set; }

    public INode? Parent { get; set; }

    public int Value { get; set; }

    public Operand(INode parent, int value)
    {
        Parent = parent;
        Value = value;
    }

    public double Evaluate()
        => Value;

    public void Print()
    {
        if (Parent.RightChild == this)
        {
            Console.Write($"{Value} ) ");
        }
        else
        {
            Console.Write($"{Value} ");
        }
    }
}