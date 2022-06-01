namespace UniqueList;

using UniqueList.Exceptions;

/// <summary>
/// Linked list implementation.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
public class MyList<T>
{
    private Node? head;
    private Node? tail;

    /// <summary>
    /// Gets length of the linked list.
    /// </summary>
    public int Length { get; private set; }

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
        if (head is null || tail is null)
        {
            head = new Node(value, null);
            tail = head;
        }
        else
        {
            tail.Next = new Node(value);
            tail = tail.Next;
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
        if (index < 0 || index > Length)
        {
            throw new IndexOutOfRangeException();
        }
        else if (head is null || index == Length)
        {
            Add(value);
        }
        else if (index == 0)
        {
            head = new Node(value, head);
            Length++;
        }
        else
        {
            var currentNode = GetNode(index, 1);
            currentNode.Next = new Node(value, currentNode.Next);
            Length++;
        }
    }

    /// <summary>
    /// Deletes an element at a specified position from the linked list.
    /// </summary>
    /// <param name="index">An index where the element is to be deleted.</param>
    /// <exception cref="DeleteFromEmptyListException">Throws if the list is empty.</exception>
    /// <exception cref="IndexOutOfRangeException">Throws if the index was outside the linked list.</exception>
    public virtual void DeleteAt(int index)
    {
        if (head is null)
        {
            throw new DeleteFromEmptyListException();
        }
        else if (index < 0 || index > Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            var currentNode = GetNode(index, 1);
            if (currentNode.Next is not null && currentNode.Next.Equals(tail))
            {
                tail = currentNode;
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
        if (head is null || head.Value is null)
        {
            throw new DeleteFromEmptyListException();
        }
        else if (head.Value.Equals(value))
        {
            head = head.Next;
            Length--;
        }
        else
        {
            var currentNode = head;
            while (currentNode.Next is not null)
            {
                if (currentNode.Next.Value is not null && currentNode.Next.Value.Equals(value))
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
    /// Indicates whether list contains the given element.
    /// </summary>
    /// <param name="value">Value index of which is to be found.</param>
    /// <returns>Index of the element if it is in the list and -1 otherwise.</returns>
    public int Contains(T value)
    {
        var currentNode = head;
        int index = 0;
        while (currentNode is not null)
        {
            if (currentNode.Value is not null && currentNode.Value.Equals(value))
            {
                return index;
            }

            index++;
            currentNode = currentNode.Next;
        }

        return -1;
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

    private Node GetNode(int index, int offset)
    {
        var currentNode = head;
        for (int i = 0; i < index - offset; i++)
        {
            if (currentNode is not null && currentNode.Next is null)
            {
                throw new IndexOutOfRangeException();
            }

            currentNode = currentNode!.Next;
        }

        return currentNode!;
    }

    private T GetValue(int index)
    {
        if (head is null)
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

    private class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public Node(T value)
            : this(value, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        /// <param name="next">Points to the next node.</param>
        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }

        /// <summary>
        /// Gets or sets value stored in the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets pointer to the next node.
        /// </summary>
        public Node? Next { get; set; }
    }
}
