namespace ConsoleGame
{
    public class InvalidMapException : System.Exception
    {
        public InvalidMapException() {}
        
        public InvalidMapException(string message) : base(message) {}
        
        public InvalidMapException(string message, System.Exception inner) : base(message, inner) {}

        public InvalidMapException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        
    }
}