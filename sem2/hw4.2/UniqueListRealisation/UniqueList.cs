using System.Collections.Generic;
using System.Linq;

namespace UniqueListRealisation
{
    /// <summary>
    /// Represents a strongly typed list of unique objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class UniqueList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public UniqueList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public UniqueList(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="ItemAlreadyExistException"><see cref="collection"/> has duplicates.</exception>
        public UniqueList(IEnumerable<T> collection)
            :base(collection)
        {
            if (IsEnumerableContainsDuplicates(collection))
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="UniqueList{T}"/>
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="UniqueList{T}"/></param>
        /// <exception cref="ItemAlreadyExistException"><see cref="item"/> is duplicate.</exception>
        public new void Add(T item)
        {
            if (Contains(item))
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");

            base.Add(item);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="UniqueList{T}"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="UniqueList{T}"/></param>
        public new void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Inserts an element into the <see cref="UniqueList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        /// <exception cref="ItemAlreadyExistException"><see cref="item"/> is duplicate.</exception>
        public new void Insert(int index, T item)
        {
            if (Contains(item))
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");
            
            base.Insert(index, item);
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="UniqueList{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="UniqueList{T}"/>.</param>
        /// <exception cref="ItemAlreadyExistException"><see cref="collection"/> has duplicates.</exception>
        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            var valuesList = collection.ToList();
            if(IsEnumerableContainsDuplicates(valuesList))
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");

            if (valuesList.Any(Contains))
            {
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");
            }
            
            base.InsertRange(index, valuesList);
        }

        /// <summary>
        /// Removes specific object from the <see cref="UniqueList{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="UniqueList{T}"/>.</param>
        /// <exception cref="ItemDoesNotExistException">The <see cref="item"/> is not contained in the <see cref="UniqueList{T}"/>.</exception>
        public new void Remove(T item)
        {
            if (!Contains(item))
                throw new ItemDoesNotExistException("Attempted to remove an item that is not in the UniqueList.");

            base.Remove(item);
        }

        /// <summary>
        /// Сhecks if the current collection contains duplicates.
        /// </summary>
        /// <param name="inputEnumerable">Collection to check.</param>
        /// <returns>True if it contains duplicates, false otherwise.</returns>
        private bool IsEnumerableContainsDuplicates(IEnumerable<T> inputEnumerable)
            => inputEnumerable.GroupBy(value => value).Count(group => group.Count() > 1) != 0;
    }
}