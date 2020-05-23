namespace UniqueListRealisation
{
    /// <summary>
    /// Represents a singly linked list with unique items. Provides methods to manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class UniqueList<T> : LinkedList<T>
    {
        /// <summary>
        /// Adds the item with the desired value to the desired position.
        /// </summary>
        /// <param name="value">The value of the element to add.</param>
        /// <param name="index">Position number counting from 0.</param>
        /// <exception cref="ItemAlreadyExistException"><see cref="value"/> is duplicate.</exception>
        public override void AddElementByIndex(T value, int index)
        {
            if (Contains(value))
                throw new ItemAlreadyExistException("Attempted to add an item that is already in the UniqueList.");

            base.AddElementByIndex(value, index);
        }

        /// <summary>
        /// Removes specific object from the <see cref="UniqueList{T}"/>.
        /// </summary>
        /// <param name="value">The object to remove from the <see cref="UniqueList{T}"/>.</param>
        /// <exception cref="ItemDoesNotExistException">The <see cref="value"/> is not contained in the <see cref="UniqueList{T}"/>.</exception>
        public override void Remove(T value)
        {
            if (!Contains(value))
                throw new ItemDoesNotExistException("Attempted to remove an item that is not in the UniqueList.");

            base.Remove(value);
        }
    }
}