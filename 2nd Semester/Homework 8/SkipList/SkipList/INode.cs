namespace SkipList;

internal interface INode<TValue>
{
    TValue Value { get; }

    INode<TValue>? Next { get; set; }

    INode<TValue>? Below { get; set; }
}
