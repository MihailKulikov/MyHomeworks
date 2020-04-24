namespace HashTableTask
{
    /// <summary>
    /// Represents a hash function. Provides methods to get hash code.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Calculate a hash code for the current string.
        /// </summary>
        /// <param name="data">Current string.</param>
        /// <returns>A hash code for the current string.</returns>
        public int GetHashCode(string data);
    }
}