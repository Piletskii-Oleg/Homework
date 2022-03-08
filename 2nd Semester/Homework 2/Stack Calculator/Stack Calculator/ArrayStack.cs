namespace StackCalculator;

/// <summary>
/// Last-In-First-Out container implemented using array.
/// </summary>
public class ArrayStack : IStack
{
    private int capacity;
    private double[] stack;
    private int currentIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayStack"/> class.
    /// </summary>
    public ArrayStack()
    {
        this.capacity = 15;
        this.stack = new double[this.capacity];
        this.currentIndex = 0;
    }

    /// <summary>
    /// Puts an element to the stack.
    /// </summary>
    /// <param name="element">Element to add.</param>
    public void Push(double element)
    {
        if (currentIndex == capacity)
        {
            capacity += 15;
            Array.Resize(ref stack, capacity);
        }
        stack[currentIndex++] = element;
    }

    /// <summary>
    /// Removes last element from the stack and returns its value.
    /// </summary>
    /// <returns>Last element from the stack.</returns>
    public double? Pop()
      => (currentIndex != 0) ? stack[--currentIndex] : null;

    /// <summary>
    /// Checks if stack is empty.
    /// </summary>
    /// <returns>Returns true if the stack is empty and false otherwise.</returns>
    public bool IsEmpty()
        => this.currentIndex == 0;
}