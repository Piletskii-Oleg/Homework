namespace UniqueList.Exceptions;

/// <summary>
/// An exception that is thrown when an element that is not contained in the linked list is attempted to be removed.
/// </summary>
public class DeleteNonexistentElementException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteNonexistentElementException"/> class.
    /// </summary>
    public DeleteNonexistentElementException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteNonexistentElementException"/> class.
    /// </summary>
    public DeleteNonexistentElementException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteNonexistentElementException"/> class.
    /// </summary>
    public DeleteNonexistentElementException(string message, Exception inner)
        : base(message, inner)
    {
    }
}