namespace ConsoleGame.Exceptions;

/// <summary>
/// Throws when there is no spawn point on the map file.
/// </summary>
[Serializable]
public class NoSpawnPointException : Exception
{
    public NoSpawnPointException() { }
    public NoSpawnPointException(string message) : base(message) { }
    public NoSpawnPointException(string message, Exception inner) : base(message, inner) { }
    protected NoSpawnPointException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
