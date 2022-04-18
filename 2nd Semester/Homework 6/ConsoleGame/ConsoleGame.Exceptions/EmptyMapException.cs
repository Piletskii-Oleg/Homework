namespace ConsoleGame.Exceptions;

/// <summary>
/// Throws when there are no objects on the map.
/// </summary>
[Serializable]
public class EmptyMapException : Exception
{
    public EmptyMapException() { }
    public EmptyMapException(string message) : base(message) { }
    public EmptyMapException(string message, Exception inner) : base(message, inner) { }
    protected EmptyMapException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
