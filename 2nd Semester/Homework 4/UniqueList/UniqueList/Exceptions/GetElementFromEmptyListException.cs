namespace UniqueList.Exceptions;

/// <summary>
/// An exception that is thrown when an attempts is made to retrieve an element from an empty linked list.
/// </summary>
public class GetElementFromEmptyListException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetElementFromEmptyListException"/> class.
    /// </summary>
    public GetElementFromEmptyListException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetElementFromEmptyListException"/> class.
    /// </summary>
    public GetElementFromEmptyListException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetElementFromEmptyListException"/> class.
    /// </summary>
    public GetElementFromEmptyListException(string message, Exception inner)
        : base(message, inner)
    {
    }
}