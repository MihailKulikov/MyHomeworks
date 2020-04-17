using System;

namespace Queue
{
    /// <summary>
    /// Represents priority queue with enqueue and dequeue methods
    /// </summary>
    /// <typeparam name="T">Value type.</typeparam>
    public class PriorityQueue<T>
    {
        /// <summary>
        /// Represents a node in a priority queue.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Gets the value contained in the node.
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// Gets priority of the node.
            /// </summary>
            public int Priority { get; }
            
            /// <summary>
            /// Gets and sets the next node in the LinkedList.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value with the specified priority.
            /// </summary>
            /// <param name="value">The value to contain in the Node.</param>
            /// <param name="priority">Priority of the item.</param>
            public Node(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value with the specified priority and the link on the next node.
            /// </summary>
            /// <param name="value">The value to contain in the Node.</param>
            /// <param name="priority">Priority of the item.</param>
            /// <param name="next">The link on the next node to contain in the Node.</param>
            public Node(T value, int priority, Node next)
            {
                Value = value;
                Next = next;
                Priority = priority;
            }
        }

        private Node _head;
        private Node _tail;

        /// <summary>
        /// Gets the number of nodes actually contained in the LinkedList.
        /// </summary>
        private int Length { get;  set;}

        /// <summary>
        /// Checks if the LinkedList is empty.
        /// </summary>
        /// <returns>True if the LinkedList is empty, and false if not.</returns>
        private bool IsEmpty()
            => _head == null;

        /// <summary>
        /// Adds an object to the end of the Queue&lt;T&gt;.
        /// </summary>
        /// <param name="value">The object to add to the priority queue.</param>
        /// <param name="priority">Priority of the added item.</param>
        public void Enqueue(T value, int priority)
        {
            var index = FindIndexOfNodeWithLowerPriority(priority);
            
            AddElementByIndex(value, priority, index);
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the priority queue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the priority queue.</returns>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new QueueIsEmptyException();
            
            var topElement = _head.Value;
            RemoveElementByIndex(0);

            return topElement;
        }

        /// <summary>
        /// Finds index of the first node with the priority lower when specified.
        /// </summary>
        /// <param name="priority">Specified priority.</param>
        /// <returns>Index of the first node with the priority lower when specified.</returns>
        private int FindIndexOfNodeWithLowerPriority(int priority)
        {
            if (IsEmpty())
                return 0;

            var current = _head;
            var index = 0;

            if (current.Priority < priority)
            {
                return index;
            }
            
            while (current.Next != null)
            {
                if (current.Priority < priority)
                {
                    return index;
                }
                
                current = current.Next;
                index++;
            }

            return Length;
        }
        
        /// <summary>
        /// Finds the item in priority queue with the desired position number.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        /// <returns>The item with the desired position number.</returns>
        private Node FindNodeByIndex(int index)
        {
            var current = _head;
            for (var i = 0; i < index; i++)
            {
                current = current.Next ?? throw new ArgumentOutOfRangeException(nameof(index));
            }

            return current;
        }

        /// <summary>
        /// Adds the item with the desired value to the desired position.
        /// </summary>
        /// <param name="value">Item value.</param>
        /// <param name="priority">Priority of the element.</param>
        /// <param name="index">Position number counting from 0.</param>
        private void AddElementByIndex(T value, int priority, int index)
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (IsEmpty())
            {
                _head = new Node(value, priority);
                _tail = _head;
                Length++;
                return;
            }

            if (index == 0)
            {
                _head = new Node(value, priority, _head);
            }
            else if (index == Length)
            {
                _tail.Next = new Node(value, priority);
                _tail = _tail.Next;
            }
            else
            {
                var previous = FindNodeByIndex(index - 1);
                var current = new Node(value, priority, previous.Next);
                previous.Next = current;
            }

            Length++;
        }

        /// <summary>
        /// Removes the item with the desired position.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        private void RemoveElementByIndex(int index)
        {
            if (index >= Length || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                var previous = FindNodeByIndex(index - 1);
                if (previous.Next.Next == null)
                {
                    _tail = previous;
                    _tail.Next = null;
                }
                else
                {
                    previous.Next = previous.Next.Next;
                }
            }

            if (IsEmpty())
            {
                _tail = null;
            }

            Length--;
        }
    }
}