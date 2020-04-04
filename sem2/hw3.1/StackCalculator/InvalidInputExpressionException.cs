using System;

namespace StackCalculator
{
    [Serializable]
    public class InvalidInputExpressionException : Exception
    {
        public InvalidInputExpressionException() { }

        public InvalidInputExpressionException(string message)
            : base(message) { }

        public InvalidInputExpressionException(string message, Exception inner)
            : base(message, inner) { }

        protected InvalidInputExpressionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}