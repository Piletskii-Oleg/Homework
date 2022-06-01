namespace Routers.Exceptions;

/// <summary>
/// An exception that is thrown when the graph built is not connected.
/// </summary>
[Serializable]
public class GraphNotConnectedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphNotConnectedException"/> class.
    /// </summary>
    public GraphNotConnectedException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphNotConnectedException"/> class.
    /// </summary>
    public GraphNotConnectedException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphNotConnectedException"/> class.
    /// </summary>
    public GraphNotConnectedException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphNotConnectedException"/> class.
    /// </summary>
    protected GraphNotConnectedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}