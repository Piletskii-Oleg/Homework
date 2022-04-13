namespace UniqueList;

using UniqueList.Exceptions;

/// <summary>
/// Linked list implementation.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
public class MyList<T>
{
    /// <summary>
    /// Gets or sets length of the linked list.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Gets head of the linked list.
    /// </summary>
    internal Node<T>? Head { get; private set; }

    /// <summary>
    /// Gets or sets a value in the linked list by index.
    /// </summary>
    /// <param name="index">Index of the element.</param>
    /// <returns>Element by the index.</returns>
    public virtual T this[int index]
    {
        get => GetValue(index);
        set => SetValue(index, value);
    }

    /// <summary>
    /// Adds an element to the end of the linked list.
    /// </summary>
    /// <param name="value">A value to add.</param>
    public virtual void Add(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(value, null);
        }
        else
        {
            Node<T> currentNode = Head;
            while (currentNode.Next is not null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new Node<T>(value, null);
        }

        Length++;
    }

    /// <summary>
    /// Inserts an element at a specified position to the linked list.
    /// </summary>
    /// <param name="index">An index to add an element at.</param>
    /// <param name="value">A value to add.</param>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    public virtual void Insert(int index, T value)
    {
        if (index == 0)
        {
            Head = new Node<T>(value, Head);
        }
        else
        {
            var currentNode = GetNode(index, 1);
            if (currentNode is null)
            {
                throw new IndexOutOfRangeException();
            }

            currentNode.Next = new Node<T>(value, currentNode.Next);
        }

        Length++;
    }

    /// <summary>
    /// Deletes an element at a specified position from the linked list.
    /// </summary>
    /// <param name="index">An index where the element is to be deleted.</param>
    /// <exception cref="DeleteFromEmptyListException">Throws if the list is empty.</exception>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    public virtual void DeleteAt(int index)
    {
        if (Head is null)
        {
            throw new DeleteFromEmptyListException();
        }

        if (index == 0)
        {
            Head = Head.Next ?? null;
        }
        else
        {
            var currentNode = GetNode(index, 1);
            if (currentNode is null)
            {
                throw new IndexOutOfRangeException();
            }

            currentNode.Next = currentNode.Next?.Next;
        }

        Length--;
    }

    /// <summary>
    /// Deletes the given element from the linked list.
    /// </summary>
    /// <param name="value">Value of an element to delete.</param>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    /// <exception cref="DeleteFromEmptyListException">Throws if the list is empty.</exception>
    /// <exception cref="DeleteNonexistentElementException">Throws if element is not contained in the list.</exception>
    public virtual void Delete(T value)
    {
        if (Head is null)
        {
            throw new DeleteFromEmptyListException();
        }
        else if (Head.Value.Equals(value))
        {
            Head = Head.Next ?? null;
            Length--;
        }
        else
        {
            var currentNode = Head;
            while (currentNode.Next is not null)
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    currentNode.Next = currentNode.Next.Next ?? null;
                    Length--;
                    return;
                }

                currentNode = currentNode.Next;
            }

            throw new DeleteNonexistentElementException();
        }
    }

    /// <summary>
    /// Gets a node at the specified position with an offset to the left.
    /// </summary>
    /// <param name="index">Index of an element.</param>
    /// <param name="offset">Offset to the left (must be 0 or 1).</param>
    /// <returns>Node at the specified position with an offset.</returns>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    /// <exception cref="ArgumentException">Throws if offset was not 0 or 1.</exception>
    internal Node<T>? GetNode(int index, int offset)
    {
        if (offset != 0 && offset != 1)
        {
            throw new ArgumentException("Offset was not 0 or 1", nameof(offset));
        }

        var currentNode = Head;
        if (currentNode is null)
        {
            return null;
        }

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

    /// <summary>
    /// Sets a value at the specified position.
    /// </summary>
    /// <param name="index">An index to change element at.</param>
    /// <param name="value">New value of an element.</param>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    protected virtual void SetValue(int index, T value)
    {
        var currentNode = GetNode(index, 0);
        if (currentNode is null)
        {
            throw new IndexOutOfRangeException();
        }

        currentNode.Value = value;
    }

    private T GetValue(int index)
    {
        if (Head is null)
        {
            throw new GetElementFromEmptyListException();
        }

        var currentNode = GetNode(index, 0);
        if (currentNode is null)
        {
            throw new IndexOutOfRangeException();
        }

        return currentNode.Value;
    }
}
