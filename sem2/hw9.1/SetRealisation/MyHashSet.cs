using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetRealisation
{
    public class MyHashSet<T> : ISet<T>
    {
        private const int InitialSize = 4;
        private LinkedList<T>[] buckets;
        private const int LoadFactor = 2;
        private const int NumberToIncrease = 2;

        bool ICollection<T>.IsReadOnly => false;

        public int Count { get; private set; }

        public IEqualityComparer<T> Comparer { get; }

        public MyHashSet() : this(EqualityComparer<T>.Default) { }

        public MyHashSet(IEqualityComparer<T> comparer) : this(new T[0], comparer) { }
        
        public MyHashSet(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default) { }

        public MyHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            Count = 0;
            buckets = new LinkedList<T>[InitialSize];

            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }
            
            Comparer = comparer;

            foreach (var item in collection)
            {
                Add(item);
            }
        }
        
        private void CheckAverageLoad()
        {
            if (Count / buckets.Length >= LoadFactor)
            {
                EnlargeHashSet();
            }
        }
        
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
        
        private int GetArrayPosition(T value, int lengthOfBuckets)
        {
            return Math.Abs(Comparer.GetHashCode(value) % lengthOfBuckets);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return buckets.SelectMany(chain => chain).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            if (!Contains(item))
            {
                buckets[GetArrayPosition(item, buckets.Length)].AddFirst(item);
                Count++;
            }
            
            CheckAverageLoad();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (var item in other)
            {
                Remove(item);
            }
        }

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

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();
            return otherAsList.Any(item => !Contains(item)) && this.All(otherAsList.Contains);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return this.Any(item => !otherAsList.Contains(item)) && otherAsList.All(Contains);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return this.All(otherAsList.Contains);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return otherAsList.All(Contains);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherAsList = other.ToList();

            return otherAsList.Any(Contains);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var otherAsList = other.ToList();
            return otherAsList.All(Contains) && this.All(otherAsList.Contains);
        }

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

        public void Clear()
        {
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            return buckets[GetArrayPosition(item, buckets.Length)].Any(element => Comparer.Equals(element, item));
        }

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