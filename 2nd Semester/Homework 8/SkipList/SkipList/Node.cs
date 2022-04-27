namespace SkipList;

public class Node<T>
{
    public Node(T value)
    {
        Value = value;
        Next = null;
    }

    public Node(T value, Node<T> next)
    {
        Value = value;
        Next = next;
    }

    public T Value { get; private set; }

    public Node<T>? Next { get; private set; }

    public int Level { get; set; } = 1;
}