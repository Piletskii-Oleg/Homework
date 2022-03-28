namespace UniqueList;

/// <summary>
/// A node of the linked list.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
internal class Node<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class.
    /// </summary>
    /// <param name="value">Value of the node.</param>
    /// <param name="next">Points to the next node.</param>
    public Node(T value, Node<T>? next)
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
    public Node<T>? Next { get; set; }
}