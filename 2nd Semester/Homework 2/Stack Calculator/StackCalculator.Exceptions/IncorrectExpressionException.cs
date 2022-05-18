namespace StackCalculator.Exceptions;

    [Serializable]
    public class IncorrectExpressionException : Exception
    {
        public IncorrectExpressionException() { }
        public IncorrectExpressionException(string message) : base(message) { }
        public IncorrectExpressionException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectExpressionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }