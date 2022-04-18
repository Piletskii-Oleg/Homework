namespace ConsoleGame.Exceptions;

/// <summary>
/// Throws when there is no space to move on the map.
/// </summary>
[Serializable]
public class NoSpaceToMoveException : Exception
{
    public NoSpaceToMoveException() { }
    public NoSpaceToMoveException(string message) : base(message) { }
    public NoSpaceToMoveException(string message, Exception inner) : base(message, inner) { }
    protected NoSpaceToMoveException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}