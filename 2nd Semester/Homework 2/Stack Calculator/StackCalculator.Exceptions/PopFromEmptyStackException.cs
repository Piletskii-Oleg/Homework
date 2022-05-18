namespace StackCalculator.Exceptions;

[Serializable]
public class PopFromEmptyStackException : Exception
{
    public PopFromEmptyStackException() { }
    public PopFromEmptyStackException(string message) : base(message) { }
    public PopFromEmptyStackException(string message, Exception inner) : base(message, inner) { }
    protected PopFromEmptyStackException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}