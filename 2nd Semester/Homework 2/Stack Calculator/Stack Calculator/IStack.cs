namespace StackCalculator;

/// <summary>
/// Interface for a last-in-first-out container.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Add an element on top of stack.
    /// </summary>
    /// <param name="value">An element to push.</param>
    void Push(double value);

    /// <summary>
    /// Remove an element from the top of stack and returns its value.
    /// </summary>
    /// <returns>Value from the top of the stack.</returns>
    double? Pop();

    /// <summary>
    /// Checks if stack is empty.
    /// </summary>
    /// <returns>Returns true if the stack is empty and false otherwise.</returns>
    bool IsEmpty();
}

