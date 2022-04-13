namespace UniqueList.Exceptions;

/// <summary>
/// An exception that is thrown when an existing element is attempted to be added to the UniqueList.
/// </summary>
public class AddExistingElementException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddExistingElementException"/> class.
    /// </summary>
    public AddExistingElementException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AddExistingElementException"/> class.
    /// </summary>
    public AddExistingElementException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AddExistingElementException"/> class.
    /// </summary>
    public AddExistingElementException(string message, Exception inner)
        : base(message, inner)
    {
    }
}