namespace UniqueList;

using UniqueList.Exceptions;

/// <summary>
/// Linked list that does not contain repeating elements.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
public class MyUniqueList<T> : MyList<T>
{
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
        if (Contains(value) != -1)
        {
            throw new AddExistingElementException();
        }

        base.Add(value);
    }

    /// <inheritdoc/>
    /// <exception cref="AddExistingElementException">Throws if the element is already contained in the list.</exception>
    public override void Insert(int index, T value)
    {
        if (Contains(value) != -1)
        {
            throw new AddExistingElementException();
        }

        base.Insert(index, value);
    }

    /// <inheritdoc/>
    public override void DeleteAt(int index)
    {
        if (Length == 0)
        {
            throw new DeleteFromEmptyListException();
        }
        else if (index < 0 || index > Length)
        {
            throw new IndexOutOfRangeException();
        }

        base.DeleteAt(index);
    }

    /// <inheritdoc/>
    /// <exception cref="DeleteNonexistentElementException">Throws if the element was not contained in the list.</exception>
    public override void Delete(T value)
    {
        if (Contains(value) == -1)
        {
            throw new DeleteNonexistentElementException();
        }

        base.Delete(value);
    }

    /// <inheritdoc/>
    /// <exception cref="AddExistingElementException">Throws if the element is already contained in the list.</exception>
    protected override void SetValue(int index, T value)
    {
        if (index < 0 || index > Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        var valueToChange = this[index];
        if (Contains(value) != -1 && valueToChange is not null && !valueToChange.Equals(value))
        {
            throw new AddExistingElementException();
        }

        base.SetValue(index, value);
    }
}
