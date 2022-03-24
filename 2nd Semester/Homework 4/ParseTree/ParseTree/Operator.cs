namespace ParseTree;

public abstract class Operator : INode
{
    public INode? LeftChild { get; set; }

    public INode? RightChild { get; set; }

    public INode? Parent { get; set; }

    public char Operation { get; set; }

    public abstract double Evaluate();

    public void Print()
        => Console.Write($"( {Operation} ");

    public Operator(INode parent, char operation)
    {
        Parent = parent;
        Operation = operation;
    }

}