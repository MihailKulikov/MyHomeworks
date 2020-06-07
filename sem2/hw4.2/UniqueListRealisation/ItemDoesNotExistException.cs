namespace UniqueListRealisation
{
    /// <summary>
    /// The exception that is thrown when a item not in the UniqueList has been tried to remove.
    /// </summary>
    public class ItemDoesNotExistException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDoesNotExistException"/> class.
        /// </summary>
        public ItemDoesNotExistException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ItemDoesNotExistException(string message) : base(message) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ItemDoesNotExistException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyExistException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.></param>
        /// <param name="context">Streaming context.</param>
        protected ItemDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}