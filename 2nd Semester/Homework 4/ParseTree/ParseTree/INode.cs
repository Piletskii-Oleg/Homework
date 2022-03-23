namespace ParseTree;

public interface INode
{
    public INode? LeftChild { get; set; }

    public INode? RightChild { get; set; }

    public INode? Parent { get; set; }

    public double Evaluate();

    public void Print();
}