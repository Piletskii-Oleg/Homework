namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private Head<T> head;

    public int MaxLevel { get; private set; } = 1;

    public int Count { get; private set; }

    public bool IsReadOnly => throw new NotImplementedException();

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotSupportedException(); }

    public SkipList()
    {
        head = new Head<T>();
    }

    public SkipList(IList<T> list)
        : this ()
    {
        foreach (T item in list)
        {
            this.Add(item);
        }
    }

    public void Add(T value)
    {
        if (head.Next is null)
        {
            head.Next = new Node<T>(value, null);
        }
        else
        {
            var previousValues = FindPreviousNodes(value);
            var currentNode = previousValues[1];
            if (currentNode.Value.Equals(value))
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
                if (MaxLevel == currentLevel - 1)
                {
                    head = new Head<T>(head);
                    previousValues.Add(currentLevel, head);
                    MaxLevel++;
                    newLevelCreated = true;
                }

                previousValues[currentLevel].Next = new Node<T>(value, previousValues[currentLevel].Next, previousValues[currentLevel - 1].Next);
                currentLevel++;
            }
        }

        Count++;
    }

    private Dictionary<int, INode<T>> FindPreviousNodes(T value)
    {
        INode<T> currentNode = head;
        var previousValues = new Dictionary<int, INode<T>>();
        var currentLevel = MaxLevel;
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

    private static int CoinFlip()
    {
        var random = new Random();
        return random.Next(2);
    }

    public void Print()
    {
        int level = MaxLevel;
        INode<T> currentHead = head;
        while (level > 0)
        {
            Console.Write((MaxLevel - level) + ": ");
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

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    void IList<T>.RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        head = new Head<T>();
        Count = 0;
        MaxLevel = 1;
    }

    public bool Contains(T item)
    {
        INode<T> currentNode = head;
        while (currentNode!.Below is not null)
        {
            while (currentNode.Next is not null && item.CompareTo(currentNode.Next.Value) >= 0)
            {
                currentNode = currentNode.Next;
            }

            currentNode = currentNode.Below;
        }

        while (currentNode!.Next is not null && item.CompareTo(currentNode.Next.Value) >= 0)
        {
            currentNode = currentNode.Next;
        }

        return currentNode.Value.Equals(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        else if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Target array was not long enough.", nameof(array));
        }
        else if (arrayIndex < 0 || arrayIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index was out of the array bounds.");
        }

        for (int i = arrayIndex; i < Count; i++)
        {
            array[i] = this[i];
        }
    }

    public bool Remove(T item)
    {
        if (head is null)
        {
            throw new InvalidOperationException();
        }
        else if (head.Value.Equals(item))
        {
            //if (head.Next is null && head.Below is not null)
            //{
            //    MaxLevel--;
            //    head = head.Below;
            //}

            //head.Below = head.Next.Below;
            //head = head.Next;
            //Count--;
            //return true;
        }
        else
        {
            var previousValues = FindPreviousNodes(item);
            if (previousValues[1].Next is not null && previousValues[1].Next.Value.Equals(item))
            {
                foreach (var value in previousValues)
                {
                    value.Value.Next = value.Value.Next?.Next;
                }

                Count--;
                return true;
            }
        }

        return false;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private class Node<TValue> : INode<TValue> where TValue : IComparable<TValue>
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
            Value = value;
            Next = next;
            Below = below;
        }

        public TValue Value { get; set; }

        public INode<TValue>? Next { get; set; }

        public INode<TValue>? Below { get; set; }
    }

    private class Head<TValue> : INode<TValue> where TValue : IComparable<TValue>
    {
        public Head()
        {
        }

        public Head(INode<TValue> below)
        {
            Below = below;
        }

        public INode<TValue>? Next { get; set; }

        public INode<TValue>? Below { get; set; }

        public TValue Value { get; set; }
    }
}
