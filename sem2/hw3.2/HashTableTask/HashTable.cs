using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashTable
{
    /// <summary>
    /// Represents a hash table. Provides methods to check for an item and manipulate hash table.
    /// </summary>
    public class HashTable : IEnumerable<string>
    {
        private LinkedList[] _buckets;
        private int _itemCount;
        private IHashFunction _hashFunction;
        private readonly TextWriter _writer;
        
        private const int Size = 4;
        private const int LoadFactor = 2;
        private const int NumberToIncrease = 2;

        /// <summary>
        /// Initializes a new, empty instance of the HashTableTask class using the default initial capacity, load factor.
        /// </summary>
        public HashTable(TextWriter writer, IHashFunction hashFunction)
        {
            _writer = writer;
            _hashFunction = hashFunction;
            _buckets = new LinkedList[Size];
            _itemCount = 0;
            for (var i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = new LinkedList(writer);
            }
        }
        
        /// <summary>
        /// Checks load average of the HashTableTask.
        /// </summary>
        private void CheckAverageLoad()
        {
            if (_itemCount / _buckets.Length >= LoadFactor)
            {
                EnlargeHashTable(NumberToIncrease);
            }
        }

        /// <summary>
        /// Increases the number of elements in the buckets by the selected number of times.
        /// </summary>
        private void EnlargeHashTable(int numberToIncrease)
        {
            var newBuckets = new LinkedList[_buckets.Length * numberToIncrease];
            for (var i = 0; i < newBuckets.Length; i++)
            {
                newBuckets[i] = new LinkedList(_writer);
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
        private int GetArrayPosition(string value, int lengthOfBuckets)
        {
            return Math.Abs(_hashFunction.GetHashCode(value)) % lengthOfBuckets;
        }

        /// <summary>
        /// Adds the item with desirable value to the HashTableTask.
        /// </summary>
        /// <param name="value">The value of the element to add.</param>
        public void Add(string value)
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
        /// Changes current hash function to the entered hash function.
        /// </summary>
        /// <param name="newHashFunction"></param>
        public void ChangeHashFunction(IHashFunction newHashFunction)
        {
            _hashFunction = newHashFunction;
            EnlargeHashTable(1);
        }
        
        /// <summary>
        /// Removes the item with desirable value from the hashTable.
        /// </summary>
        /// <param name="value">The value of the element to remove.</param>
        public void Remove(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_buckets[GetArrayPosition(value, _buckets.Length)].RemoveItemByValue(value))
            {
                _itemCount--;
            }
        }

        /// <summary>
        /// Determines whether the HashTableTask contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the HashTableTask.</param>
        /// <returns>True if the Hashtable contains an element with the specified value; otherwise, false.</returns>
        public bool IsContains(string value)
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

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return _buckets.SelectMany(bucket => bucket).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<string>) this).GetEnumerator();
        }
    }
}
