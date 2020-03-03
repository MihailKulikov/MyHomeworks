using System;

namespace HashTable
{
    /// <summary>
    /// Represents a hash table. Provides methods to check for an item and manipulate hash table.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the hash table.</typeparam>
    public class HashTable<T>
    {
        private LinkedList<T>[] _buckets;
        private const int Size = 4;
        private int _itemCount;
        private const int LoadFactor = 2;
        private const int NumberToIncrease = 2;

        /// <summary>
        /// Initializes a new, empty instance of the HashTable class using the default initial capacity, load factor.
        /// </summary>
        public HashTable()
        {
            _buckets = new LinkedList<T>[Size];
            _itemCount = 0;
            for (var i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = new LinkedList<T>();
            }
        }
        
        /// <summary>
        /// Checks load average of the HashTable.
        /// </summary>
        private void CheckAverageLoad()
        {
            if (_itemCount / _buckets.Length >= LoadFactor)
            {
                EnlargeHashTable();
            }
        }

        /// <summary>
        /// Increases the number of elements in the buckets.
        /// </summary>
        private void EnlargeHashTable()
        {
            var newBuckets = new LinkedList<T>[_buckets.Length * NumberToIncrease];
            for (int i = 0; i < newBuckets.Length; i++)
            {
                newBuckets[i] = new LinkedList<T>();
            }

            foreach (var chain in _buckets)
            {
                foreach (var item in chain)
                {
                    newBuckets[GetArrayPosition(item, newBuckets.Length)].AddElementByIndex(item, 0);
                }
            }

            _buckets = newBuckets;
        }

        /// <summary>
        /// Сounts the index of the chain for this value using a hash function.
        /// </summary>
        /// <param name="value">The value of the element to add.</param>
        /// <param name="lengthOfBuckets">Length of the current buckets</param>
        /// <returns>Index of the chain in which the element should be placed.</returns>
        private int GetArrayPosition(T value, int lengthOfBuckets)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return Math.Abs(value.GetHashCode() % lengthOfBuckets);
        }

        /// <summary>
        /// Adds the item with desirable value to the HashTable.
        /// </summary>
        /// <param name="value">The value of the element to add.</param>
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (!IsContains(value))
            {
                _buckets[GetArrayPosition(value, _buckets.Length)].AddElementByIndex(value, 0);
            }

            _itemCount++;
            CheckAverageLoad();
        }

        /// <summary>
        /// Removes the item with desirable value from the hashTable.
        /// </summary>
        /// <param name="value">The value of the element to remove.</param>
        public void Remove(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_buckets[GetArrayPosition(value, _buckets.Length)].RemoveItemsByValue(value))
            {
                _itemCount--;
            }
        }

        /// <summary>
        /// Determines whether the HashTable contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the HashTable.</param>
        /// <returns>True if the Hashtable contains an element with the specified value; otherwise, false.</returns>
        public bool IsContains(T value)
            => _buckets[GetArrayPosition(value, _buckets.Length)].IsContains(value);

        /// <summary>
        /// Prints the values of all items of hash table in the console.
        /// </summary>
        public void Print()
        {
            foreach (var chain in _buckets)
            {
                chain?.PrintList();
            }
            Console.WriteLine();
        }
    }
}
