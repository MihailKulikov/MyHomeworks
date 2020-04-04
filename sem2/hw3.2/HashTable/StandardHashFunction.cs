using System;

namespace HashTable
{
    /// <summary>
    /// Represents a default hash function. Provides methods to get hash code.
    /// </summary>
    public class StandardHashFunction : IHashFunction
    {
        public int GetHashCode(string data)
        {
            return data.GetHashCode();
        }
    }
}