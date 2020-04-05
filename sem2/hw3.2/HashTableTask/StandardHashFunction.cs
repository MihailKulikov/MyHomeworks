using System;

namespace HashTableTask
{
    /// <summary>
    /// Represents a default hash function. Provides methods to get hash code.
    /// </summary>
    public class StandardHashFunction : IHashFunction
    {
        public int GetHashCode(string data)
        {
            if (data == null)
                throw new ArgumentNullException();
            
            return data.GetHashCode();
        }
    }
}