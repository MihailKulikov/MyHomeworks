using System;

namespace Queue
{
    [Serializable]
    public class QueueIsEmptyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIsEmptyException"/> class.
        /// </summary>
        public QueueIsEmptyException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIsEmptyException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public QueueIsEmptyException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIsEmptyException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception</param>
        public QueueIsEmptyException(string message, Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIsEmptyException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context</param>
        protected QueueIsEmptyException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}