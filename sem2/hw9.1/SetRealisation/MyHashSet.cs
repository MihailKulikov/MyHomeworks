using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetRealisation
{
    /// <summary>
    /// Represents a set of values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the hash set.</typeparam>
    public class MyHashSet<T> : ISet<T>
    {
        private const int InitialSize = 4;
        private LinkedList<T>[] buckets;
        private const int LoadFactor = 2;
        private const int NumberToIncrease = 2;

        /// <summary>
        /// Gets a value indicating whether a collection is read-only.
        /// </summary>
        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the <see cref="IEqualityComparer{T}"/> object that is used to determine equality for the values in the set.
        /// </summary>
        public IEqualityComparer<T> Comparer { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHashSet{T}"/>; class that is empty and uses the default equality comparer for the set type.
        /// </summary>
        public MyHashSet() : this(EqualityComparer<T>.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHashSet{T}"/> class that is empty and uses the specified equality comparer for the set type.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or null to use the default <see cref="EqualityComparer{T}"/> implementation for the set type.</param>
        public MyHashSet(IEqualityComparer<T> comparer) : this(new T[0], comparer) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MyHashSet{T}"/> class that uses the default equality comparer for the set type, contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        public MyHashSet(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default) { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MyHashSet{T}"/> class that uses the specified equality comparer for the set type, contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or null to use the default <see cref="EqualityComparer{T}"/> implementation for the set type.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <code>null</code>.</exception>
        public MyHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            Count = 0;
            buckets = new LinkedList<T>[InitialSize];
            
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }

            Comparer = comparer ?? EqualityComparer<T>.Default;

            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }
        
        /// <summary>
        /// Checks load average of the <see cref="MyHashSet{T}"/>.
        /// </summary>
        private void CheckAverageLoad()
        {
            if (Count / buckets.Length >= LoadFactor)
            {
                EnlargeHashSet();
            }
        }
        
        /// <summary>
        /// Increases the number of elements in the buckets by the selected number of times.
        /// </summary>
        private void EnlargeHashSet()
        {
            var newBuckets = new LinkedList<T>[buckets.Length * NumberToIncrease];
            for (var i = 0; i < newBuckets.Length; i++)
            {
                newBuckets[i] = new LinkedList<T>();
            }

            foreach (var item in this)
            {
                newBuckets[GetArrayPosition(item, newBuckets.Length)].AddFirst(item);
            }

            buckets = newBuckets;
        }

        /// <summary>
        /// Сounts the index of the chain for this value using a hash function.
        /// </summary>
        /// <param name="value">The value of the element to add.</param>
        /// <param name="lengthOfBuckets">Length of the current buckets.</param>
        /// <returns>Index of the chain in which the element should be placed.</returns>
        private int GetArrayPosition(T value, int lengthOfBuckets)
            => Math.Abs(Comparer.GetHashCode(value) % lengthOfBuckets);

        /// <summary>
        /// Returns an enumerator that iterates through a <see cref="MyHashSet{T}"/> object.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> object for the <see cref="MyHashSet{T}"/> object.</returns>
        public IEnumerator<T> GetEnumerator()
            => buckets.SelectMany(chain => chain).GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Adds an item to an <see cref="ICollection{T}"/> object.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="ICollection{T}"/> object.</param>
        void ICollection<T>.Add(T item)
        {
            if (!Contains(item))
            {
                buckets[GetArrayPosition(item, buckets.Length)].AddFirst(item);
                Count++;
            }
            
            CheckAverageLoad();
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current <see cref="MyHashSet{T}"/> object.
        /// </summary>
        /// <param name="other">The collection of items to remove from the <see cref="MyHashSet{T}"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <code>null</code>.</exception>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (ReferenceEquals(this, other))
            {
                Count = 0;
                buckets = new LinkedList<T>[InitialSize];
            
                for (var i = 0; i < buckets.Length; i++)
                {
                    buckets[i] = new LinkedList<T>();
                }
            }

            foreach (var item in other)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// Modifies the current <see cref="MyHashSet{T}"/> object to contain only elements that are present in that object and in the specified collection.
        /// </summary>
        /// <param name="other">The collection of items to remove from the <see cref="MyHashSet{T}"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is <code>null</code>.</exception>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var itemsToRemove = new LinkedList<T>();
            
            foreach (var item in this.Where(item => !other.Contains(item)))
            {
                itemsToRemove.AddLast(item);
            }

            foreach (var itemToRemove in itemsToRemove)
            {
                Remove(itemToRemove);
            }
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object is a proper subset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns><code>true</code> if the <see cref="MyHashSet{T}"/> object is a proper subset of <param name="other"></param>; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentNullException">other is null.</exception>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();
            return otherAsList.Any(item => !Contains(item)) && this.All(otherAsList.Contains);
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object is a proper superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object is a proper superset of <paramref name="other"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return this.Any(item => !otherAsList.Contains(item)) && otherAsList.All(Contains);
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object is a subset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object is a subset of <paramref name="other"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">o<paramref name="other"/> is null.</exception>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return this.All(otherAsList.Contains);
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object is a superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object is a superset of <paramref name="other"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return otherAsList.All(Contains);
        }

        /// <summary>
        /// Determines whether the current <see cref="MyHashSet{T}"/> object and a specified collection share common elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object and <paramref name="other"/> share at least one common element; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return otherAsList.Any(Contains);
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object is equal to <paramref name="other"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var otherAsList = other.ToList();
            return otherAsList.All(Contains) && this.All(otherAsList.Contains);
        }

        /// <summary>
        /// Modifies the current <see cref="MyHashSet{T}"/> object to contain only elements that are present either in that object or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (var item in other.GroupBy(item => item, Comparer).Select(group => group.Key))
            {
                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Modifies the current <see cref="MyHashSet{T}"/> object to contain all elements that are present in itself, the specified collection, or both.
        /// </summary>
        /// <param name="other">The collection to compare to the current <see cref="MyHashSet{T}"/> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null.</exception>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (var item in other)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the <see cref="MyHashSet{T}"/> object; false if the element is already present.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        public bool Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Contains(item))
            {
                return false;
            }

            buckets[GetArrayPosition(item, buckets.Length)].AddFirst(item);
            Count++;
            
            CheckAverageLoad();

            return true;
        }
        
        /// <summary>
        /// Removes all elements from a <see cref="MyHashSet{T}"/> object.
        /// </summary>
        public void Clear()
        {
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }

            Count = 0;
        }

        /// <summary>
        /// Determines whether a <see cref="MyHashSet{T}"/> object contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate in the <see cref="MyHashSet{T}"/> object.</param>
        /// <returns>true if the <see cref="MyHashSet{T}"/> object contains the specified element; otherwise, false.</returns>
        public bool Contains(T item) 
            => buckets[GetArrayPosition(item, buckets.Length)].Any(element => Comparer.Equals(element, item));

            /// <summary>
        /// Copies the elements of a <see cref="MyHashSet{T}"/> object to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the <see cref="MyHashSet{T}"/> object. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="ArgumentException">The number of elements in the  <see cref="MyHashSet{T}"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException(nameof(arrayIndex));
            }

            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Removes the specified element from a <see cref="MyHashSet{T}"/> object.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if item is not found in the <see cref="MyHashSet{T}"/> object.</returns>
        public bool Remove(T item)
        {
            foreach (var itemToRemove in buckets[GetArrayPosition(item, buckets.Length)].Where(element => Comparer.Equals(item, element)))
            {
                buckets[GetArrayPosition(item, buckets.Length)].Remove(itemToRemove);
                Count--;
                    
                return true;
            }

            return false;
        }
    }
}