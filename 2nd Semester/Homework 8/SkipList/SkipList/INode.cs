namespace SkipList;

/// <summary>
/// Interface that represents a node of the skip list.
/// </summary>
/// <typeparam name="TValue">Value type.</typeparam>
internal interface INode<TValue>
{
    /// <summary>
    /// Gets value stored in the node.
    /// </summary>
    TValue Value { get; }

    /// <summary>
    /// Gets or sets pointer to the next element.
    /// </summary>
    INode<TValue>? Next { get; set; }

    /// <summary>
    /// Gets or sets pointer to the element below the current one.
    /// </summary>
    INode<TValue>? Below { get; set; }
}
