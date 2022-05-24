namespace SkipList;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class that implements the skip list data structure.
/// </summary>
/// <typeparam name="T">Value type.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private Head<T> head;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    public SkipList()
    {
        this.head = new Head<T>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
    /// </summary>
    /// <param name="list"><see cref="IList{T}"/> to copy elements from.</param>
    public SkipList(IList<T> list)
        : this()
    {
        foreach (T item in list)
        {
            this.Add(item);
        }
    }

    /// <summary>
    /// Gets maximum level of the <see cref="SkipList{T}"/>.
    /// </summary>
    public int MaxLevel { get; private set; } = 1;

    /// <summary>
    /// Gets the number of elements stored in the <see cref="SkipList{T}"/>.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the <see cref="SkipList{T}"/> is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets element at the specified index. Setting is not supported.
    /// </summary>
    /// <param name="index">Position in the <see cref="SkipList{T}"/>.</param>
    /// <returns> Value of the element at the specified index.</returns>
    /// <exception cref="NotSupportedException">Throws when attempt to set the value is made.</exception>
    public T this[int index] { get => this.GetValue(index); set => throw new NotSupportedException(); }

    /// <summary>
    /// Adds an item to the <see cref="SkipList{T}"/>.
    /// </summary>
    /// <param name="value">A value to add.</param>
    /// <exception cref="InvalidOperationException">Throws when an element with existing value is attempted to be added.</exception>
    public void Add(T value)
    {
        if (this.head.Next is null)
        {
            this.head.Next = new Node<T>(value, null);
        }
        else
        {
            var previousValues = this.GetPreviousNodes(value);
            var currentNode = previousValues[1];
            if (currentNode.Next is not null && currentNode.Next.Value.Equals(value))
            {
                throw new InvalidOperationException();
            }

            while (currentNode.Below is not null)
            {
                currentNode = currentNode.Below;
            }

            previousValues[1].Next = new Node<T>(value, previousValues[1].Next);
            bool newLevelCreated = false;
            var currentLevel = 2;
            while (!newLevelCreated && CoinFlip() == 1)
            {
                if (this.MaxLevel == currentLevel - 1)
                {
                    this.head = new Head<T>(this.head);
                    previousValues.Add(currentLevel, this.head);
                    this.MaxLevel++;
                    newLevelCreated = true;
                }

                previousValues[currentLevel].Next = new Node<T>(value, previousValues[currentLevel].Next, previousValues[currentLevel - 1].Next);
                currentLevel++;
            }
        }

        this.Count++;
    }

    /// <summary>
    /// Prints elements of the <see cref="SkipList{T}"/> on the screen preserving the list structure.
    /// </summary>
    public void Print()
    {
        if (this.head.Next is not null)
        {
            int level = this.MaxLevel;
            INode<T>? currentHead = this.head;
            while (currentHead is not null)
            {
                Console.Write((this.MaxLevel - level) + ": ");
                var currentNode = currentHead.Next;
                while (currentNode is not null)
                {
                    Console.Write(currentNode.Value + " ");
                    currentNode = currentNode.Next;
                }

                Console.WriteLine();
                currentHead = currentHead.Below;
                level--;
            }
        }
    }

    /// <summary>
    /// Determines the index of a specific item in the <see cref="SkipList{T}"/>.
    /// </summary>
    /// <param name="item">Item to find index of.</param>
    /// <returns>The index of <paramref name="item"/> if found in the list; otherwise, -1.</returns>
    public int IndexOf(T item)
    {
        if (this.head.Next is null)
        {
            return -1;
        }

        INode<T> currentNode = this.head;
        while (currentNode.Below is not null)
        {
            currentNode = currentNode.Below;
        }

        int index = -1;
        while (currentNode.Next is not null && item.CompareTo(currentNode.Next.Value) >= 0)
        {
            currentNode = currentNode.Next;
            index++;
        }

        if (currentNode.Value.Equals(item))
        {
            return index;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// (Not supported) Inserts an item to the <see cref="SkipList{T}"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="item"/> should be added.</param>
    /// <param name="item">An element to add.</param>
    /// <exception cref="NotSupportedException">Throws when the method is called.</exception>
    public void Insert(int index, T item)
        => throw new NotSupportedException();

    /// <summary>
    /// Removes the <see cref="SkipList.SkipList{T}"/> item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Throws when <paramref name="index"/> is out of range of the list.</exception>
    public void RemoveAt(int index)
        => this.Remove(this[index]);

    /// <summary>
    /// Removes all items from the <see cref="SkipList.SkipList{T}"/>.
    /// </summary>
    public void Clear()
    {
        this.head = new Head<T>();
        this.Count = 0;
        this.MaxLevel = 1;
    }

    /// <summary>
    /// Determines whether the <see cref="SkipList{T}"/> contains the specified value.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="SkipList{T}"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="item"/> is present in the <see cref="SkipList{T}"/> and <see langword="false"/> otherwise.</returns>
    public bool Contains(T item)
    {
        if (this.head.Next is null)
        {
            return false;
        }

        INode<T>? currentNode = this.head;
        while (currentNode!.Below is not null)
        {
            while (currentNode.Next is not null && item.CompareTo(currentNode.Next.Value) >= 0)
            {
                currentNode = currentNode.Next;
            }

            currentNode = currentNode.Below;
        }

        while (currentNode.Next is not null && item.CompareTo(currentNode.Next.Value) >= 0)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value.Equals(item);
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        else if (arrayIndex < 0 || arrayIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index was out of the array bounds.");
        }
        else if (array.Length - arrayIndex < this.Count)
        {
            throw new ArgumentException("Target array was not long enough.", nameof(array));
        }

        for (int i = arrayIndex; i < this.Count; i++)
        {
            array[i] = this[i];
        }
    }

    /// <summary>
    /// Removes the element from the <see cref="SkipList{T}"/>.
    /// </summary>
    /// <inheritdoc/>
    public bool Remove(T item)
    {
        if (this.head.Next is null)
        {
            throw new InvalidOperationException();
        }

        var previousValues = this.GetPreviousNodes(item);
        if (previousValues[1].Next is not null && previousValues[1].Next!.Value.Equals(item))
        {
            foreach (var value in previousValues)
            {
                value.Value.Next = value.Value.Next?.Next;
            }

            while (this.head.Next is null && this.head.Below is not null)
            {
                this.head = this.head.Below as Head<T>;
                this.MaxLevel--;
            }

            this.Count--;
            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        INode<T>? currentNode = this.head;
        var list = new List<T>();
        while (currentNode.Below is not null)
        {
            currentNode = currentNode.Below;
        }

        if (currentNode.Next is not null)
        {
            currentNode = currentNode.Next;
            while (currentNode is not null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode?.Next;
            }
        }

        return list.GetEnumerator();
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    private static int CoinFlip()
    {
        var random = new Random();
        return random.Next(2);
    }

    private Dictionary<int, INode<T>> GetPreviousNodes(T value)
    {
        INode<T>? currentNode = this.head;
        var previousValues = new Dictionary<int, INode<T>>();
        var currentLevel = this.MaxLevel;
        while (currentNode!.Below is not null)
        {
            while (currentNode.Next is not null && value.CompareTo(currentNode.Next.Value) > 0)
            {
                currentNode = currentNode.Next;
            }

            previousValues.Add(currentLevel, currentNode);
            currentLevel--;
            currentNode = currentNode.Below;
        }

        while (currentNode!.Next is not null && value.CompareTo(currentNode.Next.Value) > 0)
        {
            currentNode = currentNode.Next;
        }

        previousValues.Add(1, currentNode);
        return previousValues;
    }

    private INode<T> GetPreviousByIndex(int index)
    {
        INode<T> currentNode = this.head;
        while (currentNode.Below is not null)
        {
            currentNode = currentNode.Below;
        }

        int currentIndex = -1;
        while (currentNode.Next is not null && currentIndex < index - 1)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        return currentNode;
    }

    private T GetValue(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var previousNode = this.GetPreviousByIndex(index);
        return previousNode.Next!.Value;
    }

    private class Node<TValue> : INode<TValue>
        where TValue : IComparable<TValue>
    {
        public Node(TValue value)
            : this(value, null, null)
        {
        }

        public Node(TValue value, INode<TValue>? next)
            : this(value, next, null)
        {
        }

        public Node(TValue value, INode<TValue>? next, INode<TValue>? below)
        {
            this.Value = value;
            this.Next = next;
            this.Below = below;
        }

        public TValue Value { get; set; }

        public INode<TValue>? Next { get; set; }

        public INode<TValue>? Below { get; set; }
    }

    private class Head<TValue> : INode<TValue>
        where TValue : IComparable<TValue>
    {
        public Head()
        {
        }

        public Head(INode<TValue> below)
        {
            this.Below = below;
        }

        public INode<TValue>? Next { get; set; }

        public INode<TValue>? Below { get; set; }

        public TValue Value { get => this.Next is null ? throw new InvalidOperationException() : this.Next.Value; }
    }
}
