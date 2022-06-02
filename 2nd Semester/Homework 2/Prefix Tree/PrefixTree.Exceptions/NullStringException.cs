namespace PrefixTree.Exceptions;

/// <summary>
/// Throws when the input string is null.
/// </summary>
[Serializable]
public class NullStringException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullStringException"/> class.
    /// </summary>
    public NullStringException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NullStringException"/> class.
    /// </summary>
    public NullStringException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NullStringException"/> class.
    /// </summary>
    public NullStringException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NullStringException"/> class.
    /// </summary>
    protected NullStringException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}