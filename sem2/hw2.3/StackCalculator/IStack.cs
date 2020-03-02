namespace StackCalculator
{
    /// <summary>
    /// Represents a interface of the stack.
    /// </summary>
    interface IStack
    {
        /// <summary>
        /// Removes and returns the number at the top of the Stack.
        /// </summary>
        /// <returns>Removed number.</returns>
        double Pop();

        /// <summary>
        /// Inserts an number at the top of the Stack.
        /// </summary>
        /// <param name="value">The number to push onto the Stack.</param>
        void Push(double value);

        /// <summary>
        /// Gets the number of elements contained in the Stack.
        /// </summary>
        public int Count { get; }
    }
}
