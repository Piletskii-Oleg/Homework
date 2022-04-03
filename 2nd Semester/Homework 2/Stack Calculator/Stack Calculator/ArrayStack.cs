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
        if (this.currentIndex == this.capacity)
        {
            this.capacity += 15;
            Array.Resize(ref this.stack, this.capacity);
        }

        this.stack[this.currentIndex++] = element;
    }

    /// <summary>
    /// Removes last element from the stack and returns its value.
    /// </summary>
    /// <returns>Last element from the stack.</returns>
    public double? Pop()
      => (this.currentIndex != 0) ? this.stack[--this.currentIndex] : null;

    /// <summary>
    /// Checks if stack is empty.
    /// </summary>
    /// <returns>Returns true if the stack is empty and false otherwise.</returns>
    public bool IsEmpty()
        => this.currentIndex == 0;
}