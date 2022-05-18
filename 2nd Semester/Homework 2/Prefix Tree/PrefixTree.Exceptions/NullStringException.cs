namespace PrefixTree.Exceptions;

    [Serializable]
    public class NullStringException : Exception
    {
        public NullStringException() { }
        public NullStringException(string message) : base(message) { }
        public NullStringException(string message, Exception inner) : base(message, inner) { }
        protected NullStringException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }