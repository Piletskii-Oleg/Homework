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
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Value of the current element.</param>
        /// <param name="next">Points to the next element.</param>
        public Node(double value, Node? next)
        {
            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Gets or sets a value stored in an element.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Points to the next element.
        /// </summary>
        public Node? Next { get; set; }
    }

    private Node? root;

    /// <summary>
    /// Add an element on top of stack.
    /// </summary>
    /// <param name="value">An element to push.</param>
    public void Push(double value)
        => this.root = new Node(value, this.root);

    /// <summary>
    /// Remove an element from the top of stack and returns its value.
    /// </summary>
    /// <returns>Value from the top of the stack.</returns>
    public double? Pop()
    {
        double? removed = this.root?.Value ?? null;
        this.root = this.root?.Next;
        return removed;
    }

    /// <summary>
    /// Checks if stack is empty.
    /// </summary>
    /// <returns>Returns true if the stack is empty and false otherwise.</returns>
    public bool IsEmpty()
       => this.root == null;
}