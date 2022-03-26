namespace UniqueList;

public class MyUniqueList<T> : MyList<T>
{
    private Node<T>? root = null;

    private Dictionary<T, T> containedElements = new Dictionary<T, T>();

    public override T this[int index] 
    { 
        get => base[index];
        set => SetValue(index, value);
    }

    public override void Add(T value)
    {
        if (containedElements.ContainsKey(value))
        {
            throw new NotImplementedException(); //implement
        }

        base.Add(value);
        containedElements.Add(value, value);
    }

    public override void Insert(int index, T value)
    {
        if (containedElements.ContainsKey(value))
        {
            throw new NotImplementedException(); // implement
        }

        base.Insert(index, value);
        containedElements.Add(value, value);
    }

    public override void Delete(int index)
    {
        var nodeToDelete = GetNode(index, 0);
        base.Delete(index);
        containedElements.Remove(nodeToDelete.Value);
    }

    protected override void SetValue(int index, T value)
    {
        if (containedElements.ContainsKey(value))
        {
            throw new NotImplementedException(); // implement
        }

        var nodeToChange = GetNode(index, 0);
        containedElements.Remove(value);
        base.SetValue(index, value);
    }
}
