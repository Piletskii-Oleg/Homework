namespace Routers.Exceptions;

[Serializable]
public class GraphNotConnectedException : Exception
{
    public GraphNotConnectedException() { }

    public GraphNotConnectedException(string message) : base(message) { }

    public GraphNotConnectedException(string message, Exception inner) : base(message, inner) { }

    protected GraphNotConnectedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}