namespace UniqueListRealisation
{
    /// <summary>
    /// The exception that is thrown when a duplicate of item stored in the UniqueList has been tried to add.
    /// </summary>
    public class ItemAlreadyExistException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyExistException"/> class.
        /// </summary>
        public ItemAlreadyExistException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ItemAlreadyExistException(string message) : base(message) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ItemAlreadyExistException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyExistException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.></param>
        /// <param name="context">Streaming context.</param>
        protected ItemAlreadyExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}