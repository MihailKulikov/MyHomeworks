using System;

namespace StackCalculator
{
    /// <summary>
    /// Represents a simple last-in-first-out (LIFO) collection of double. Uses linked list.
    /// </summary>
    public class StackWithList : IStack
    {
        /// <summary>
        /// Represent a node in a linked list.
        /// </summary>
        private class Node
        {
            public double Value { get; }
            public Node Next { get; }

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value.
            /// </summary>
            /// <param name="value">The value to contain in the Node</param>
            public Node(double value)
            {
                Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value and link on the next node.
            /// </summary>
            /// <param name="value">The value to contain in the Node</param>
            /// <param name="next">The link on the next node to contain in the Node</param>
            public Node(double value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node _head;

        public int Count { get; private set; }

        public void Push(double value)
        {
            _head = _head == null ? new Node(value) : new Node(value, _head);

            Count++;
        }

        public double Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty.");
            }

            var topOfStack = _head.Value;
            _head = _head.Next;
            Count--;

            return topOfStack;
        }
    }
}
