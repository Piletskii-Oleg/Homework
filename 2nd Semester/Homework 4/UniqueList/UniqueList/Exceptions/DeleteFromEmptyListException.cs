namespace UniqueList.Exceptions;

/// <summary>
/// An exception that is thrown when it is attempted to delete an element from the linked list.
/// </summary>
public class DeleteFromEmptyListException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteFromEmptyListException"/> class.
    /// </summary>
    public DeleteFromEmptyListException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteFromEmptyListException"/> class.
    /// </summary>
    public DeleteFromEmptyListException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteFromEmptyListException"/> class.
    /// </summary>
    public DeleteFromEmptyListException(string message, Exception inner)
        : base(message, inner)
    {
    }
}