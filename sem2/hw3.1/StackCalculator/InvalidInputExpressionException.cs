using System;

namespace StackCalculator
{
    public class InvalidInputExpressionException : Exception
    {
        public InvalidInputExpressionException()
        {
        }

        public InvalidInputExpressionException(string message)
            : base(message)
        {
        }

        public InvalidInputExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}