namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private Node<T>? head;

    public int MaxLevel { get; private set; } = 1;

    int ICollection<T>.Count => throw new NotImplementedException();

    bool ICollection<T>.IsReadOnly => throw new NotImplementedException();

    T IList<T>.this[int index] { get => throw new NotImplementedException(); set => throw new NotSupportedException(); }

    public SkipList()
    {
        head = null;
    }

    public SkipList(IList<T> list)
    {
        foreach (T item in list)
        {
            this.Add(item);
        }
    }

    public void Add(T value)
    {
        if (head is null)
        {
            head = new Node<T>(value, null);
        }
        else if (value.CompareTo(head.Value) < 0)
        {
            //var headStorage = head;
            //var currentLevel = MaxLevel;
            //while (currentLevel > 0)
            //{
            //    head = new Node<T>(value, head, head.Below);
            //    currentLevel--;
            //}

            //head = headStorage;

            throw new NotImplementedException();
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
                    head = new Node<T>(head.Value, null, head);
                    previousValues.Add(currentLevel, head);
                    MaxLevel++;
                    newLevelCreated = true;
                }

                previousValues[currentLevel].Next = new Node<T>(value, previousValues[currentLevel].Next, previousValues[currentLevel - 1].Next);
                currentLevel++;
            }
        }
    }

    public void Print()
    {
        int level = MaxLevel;
        var currentHead = head;
        while (level > 0)
        {
            Console.Write((MaxLevel - level) + ": ");
            var currentNode = currentHead;
            while (currentNode is not null)
            {
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
            currentHead = currentHead!.Below;
            level--;
        }
    }

    private Dictionary<int, Node<T>> FindPreviousNodes(T value)
    {
        var currentNode = head;
        var previousValues = new Dictionary<int, Node<T>>();
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

    int IList<T>.IndexOf(T item)
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

    }

    bool ICollection<T>.Contains(T item)
    {
        throw new NotImplementedException();
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    bool ICollection<T>.Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private class Node<TValue> where TValue : IComparable<T>
    {
        public Node(T value)
            : this(value, null, null)
        {
        }

        public Node(T value, Node<T>? next)
            : this(value, next, null)
        {
        }

        public Node(T value, Node<T>? next, Node<T>? below)
        {
            Value = value;
            Next = next;
            Below = below;
        }

        public T Value { get; private set; }

        public Node<T>? Next { get; set; }

        public Node<T>? Below { get; private set; }
    }
}
