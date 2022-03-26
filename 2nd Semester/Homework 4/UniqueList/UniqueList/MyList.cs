namespace UniqueList;

public class MyList<T>
{
    private Node<T>? root = null;

    public int Length { get; set; } = 0;

    public virtual T this[int index]
    {
        get => GetValue(index);
        set => SetValue(index, value);
    }

    public virtual void Add(T value)
    {
        if (root is null)
        {
            root = new Node<T>(value, null);
        }
        else
        {
            Node<T> currentNode = root;
            while (currentNode.Next is not null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new Node<T>(value, null);
        }
        Length++;
    }

    public virtual void Insert(int index, T value)
    {
        if (index == 0)
        {
            root = new Node<T>(value, root);
        }
        else
        {
            var currentNode = GetNode(index, 1);
            currentNode.Next = new Node<T>(value, currentNode.Next);
        }
        Length++;
    }

    public virtual void Delete(int index)
    {
        if (root is null)
        {
            throw new InvalidOperationException("Cannot delete an element from an empty list");
        }

        if (index == 0)
        {
            root = root.Next ?? null;
        }
        else
        {
            var currentNode = GetNode(index, 1);
            currentNode.Next = (index == Length - 1) ? null : currentNode.Next.Next;
        }
        Length--;
    }

    private T GetValue(int index)
    {
        if (root is null)
        {
            throw new InvalidOperationException("Cannot get any value from an empty list.");
        }
        var currentNode = GetNode(index, 0);
        return currentNode.Value;
    }

    protected virtual void SetValue(int index, T value)
    {
        var currentNode = GetNode(index, 0);
        currentNode.Value = value;
    }

    internal Node<T>? GetNode(int index, int offset)
    {
        var currentNode = root;
        for (int i = 0; i < index - offset; i++)
        {
            if (currentNode.Next is null)
            {
                throw new IndexOutOfRangeException();
            }
            currentNode = currentNode.Next;
        }

        return currentNode;
    }
}
