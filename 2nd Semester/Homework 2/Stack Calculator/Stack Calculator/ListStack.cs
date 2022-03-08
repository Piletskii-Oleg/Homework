namespace StackCalculator;

/// <summary>
/// Last-In-First-Out container implemented using linked list.
/// </summary>
public class ListStack : IStack
{
    /// <summary>
    /// An element from a linked list.
    /// </summary>
    internal class Node
    {
        /// <summary>
        /// Gets or sets value stored in an element.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets points to the next element.
        /// </summary>
        public Node? Next { get; set; }

        public Node(double value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? root;

    /// <summary>
    /// Add an element on top of stack.
    /// </summary>
    /// <param name="value">An element to push.</param>
    public void Push(double value)
        => root = new Node(value, root);

    /// <summary>
    /// Remove an element from the top of stack and returns its value.
    /// </summary>
    /// <returns>Value from the top of the stack.</returns>
    public double? Pop()
    {
        double? removed = root?.Value ?? null;
        root = root?.Next;
        return removed;
    }

    /// <summary>
    /// Checks if stack is empty.
    /// </summary>
    /// <returns>Returns true if the stack is empty and false otherwise.</returns>
    public bool IsEmpty()
       => root == null;
}