using System;

namespace HashTable
{
    /// <summary>
    /// Represents a polynomial rolling hash function. Provides methods to get hash code.
    /// </summary>
    public class PolynomialRollingHashFunction : IHashFunction
    {
        public int GetHashCode(string data)
        {
            const int p = 31;
            const int m = int.MaxValue;
            int hashValue = 0;
            int pPow = 1;
            foreach (var symbol in data)
            {
                hashValue = (hashValue + (symbol - 'a' + 1) * pPow) % m;
                pPow = (pPow * p) % m;
            }

            return hashValue;
        }
    }
}