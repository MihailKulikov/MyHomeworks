using System;

namespace ExpressionTreeTask
{
    [Serializable]
    public class InvalidInputExpressionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputExpressionException"/> class.
        /// </summary>
        public InvalidInputExpressionException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputExpressionException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidInputExpressionException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputExpressionException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception</param>
        public InvalidInputExpressionException(string message, Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidInputExpressionException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context</param>
        protected InvalidInputExpressionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}