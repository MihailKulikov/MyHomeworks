namespace ConsoleGame
{
    /// <summary>
    /// The exception that is thrown when a map has incorrect format.
    /// </summary>
    public class InvalidMapException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMapException"/> class.
        /// </summary>
        public InvalidMapException() {}
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMapException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidMapException(string message) : base(message) {}
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMapException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public InvalidMapException(string message, System.Exception inner) : base(message, inner) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidMapException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        public InvalidMapException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        
    }
}