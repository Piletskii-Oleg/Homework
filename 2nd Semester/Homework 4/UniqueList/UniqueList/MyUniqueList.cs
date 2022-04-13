namespace UniqueList;

using UniqueList.Exceptions;

/// <summary>
/// Linked list that does not contain repeating elements.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
public class MyUniqueList<T> : MyList<T>
{
    private readonly HashSet<T> containedElements = new ();

    /// <inheritdoc/>
    public override T this[int index]
    {
        get => base[index];
        set => SetValue(index, value);
    }

    /// <inheritdoc/>
    /// <exception cref="AddExistingElementException">Throws if the element is already contained in the list.</exception>
    public override void Add(T value)
    {
        if (containedElements.Contains(value))
        {
            throw new AddExistingElementException();
        }

        base.Add(value);
        containedElements.Add(value);
    }

    /// <inheritdoc/>
    /// <exception cref="AddExistingElementException">Throws if the element is already contained in the list.</exception>
    public override void Insert(int index, T value)
    {
        if (containedElements.Contains(value))
        {
            throw new AddExistingElementException();
        }

        base.Insert(index, value);
        containedElements.Add(value);
    }

    /// <inheritdoc/>
    public override void DeleteAt(int index)
    {
        var nodeToDelete = GetNode(index, 0);
        if (nodeToDelete is null)
        {
            throw new DeleteFromEmptyListException();
        }

        base.DeleteAt(index);
        containedElements.Remove(nodeToDelete.Value);
    }

    /// <inheritdoc/>
    /// <exception cref="DeleteNonexistentElementException">Throws if the element was not contained in the list.</exception>
    public override void Delete(T value)
    {
        if (!containedElements.Contains(value))
        {
            throw new DeleteNonexistentElementException();
        }

        containedElements.Remove(value);
        base.Delete(value);
    }

    /// <inheritdoc/>
    /// <exception cref="AddExistingElementException">Throws if the element is already contained in the list.</exception>
    protected override void SetValue(int index, T value)
    {
        if (containedElements.Contains(value))
        {
            throw new AddExistingElementException();
        }

        var nodeToChange = GetNode(index, 0);
        if (nodeToChange is null)
        {
            throw new IndexOutOfRangeException();
        }

        containedElements.Remove(nodeToChange.Value);
        containedElements.Add(value);
        base.SetValue(index, value);
    }
}
