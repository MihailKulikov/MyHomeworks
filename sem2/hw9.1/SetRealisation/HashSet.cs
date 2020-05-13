using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetRealisation
{
    public class HashSet<T> : ISet<T>
    {
        private int count;
        private const int InitialSize = 4;
        private LinkedList<T>[] buckets;
        private const int LoadFactor = 2;
        private const int NumberToIncrease = 2;

        public bool IsReadOnly { get; }

        public int Count => count;

        public IEqualityComparer<T> Comparer { get; }

        public HashSet() : this(EqualityComparer<T>.Default) { }

        public HashSet(IEqualityComparer<T> comparer)
        {
            count = 0;
            buckets = new LinkedList<T>[InitialSize];
            
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }
            
            Comparer = comparer;
            IsReadOnly = false;
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

            foreach (var chain in buckets)
            {
                foreach (var item in chain)
                {
                    newBuckets[GetArrayPosition(item, newBuckets.Length)].AddFirst(item);
                }
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
                count++;
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
                if (Remove(item))
                {
                    count--;
                }
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (var chain in buckets)
            {
                foreach (var item in chain.Where(item => !other.Contains(item)))
                {
                    Remove(item);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            var otherList = other as T[] ?? other.ToArray();
            return otherList.All(Contains) && this.All(otherList.Contains);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (var item in other)
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
            count++;
            
            CheckAverageLoad();

            return true;
        }

        public void Clear()
        {
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new LinkedList<T>();
            }

            count = 0;
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

            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException(
                    "The number of elements in the source ICollection<T> is greater than the available space from arrayIndex to the end of the destination array.");
            }

            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            if (buckets[GetArrayPosition(item, buckets.Length)].Remove(item))
            {
                count--;
                
                return true;
            }

            return false;

        }
    }
}