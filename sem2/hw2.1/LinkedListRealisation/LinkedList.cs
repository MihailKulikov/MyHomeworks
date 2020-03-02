using System;

namespace LinkedListRealisation
{
    /// <summary>
    /// Represents a singly linked list. Provides methods to search and manipulate lists.
    /// </summary>
    /// <typeparam name="T">Value type.</typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// Represents a node in a LinkedList.
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Gets and sets the value contained in the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Gets and sets the next node in the LinkedList.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value.
            /// </summary>
            /// <param name="value">The value to contain in the Node.</param>
            public Node(T value) => Value = value;

            /// <summary>
            /// Initializes a new instance of the Node class, containing the specified value and the link on the next node.
            /// </summary>
            /// <param name="value">The value to contain in the Node.</param>
            /// <param name="next">The link on the next node to contain in the Node.</param>
            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node head;
        private Node tail;

        /// <summary>
        /// Gets the number of nodes actually contained in the LinkedList.
        /// </summary>
        public int Length { get; private set;}

        /// <summary>
        /// Checks if the LinkedList is empty.
        /// </summary>
        /// <returns>True if the LinkedList is empty, and false if not.</returns>
        public bool IsEmpty()
            => head == null;

        /// <summary>
        /// Finds the item in Linked List with the desired position number.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        /// <returns>The item with the desired position number.</returns>
        private Node FindNodeByIndex(int index)
        {
            var current = head;
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
        /// <param name="index">Position number counting from 0.</param>
        public void AddElementByIndex(T value, int index)
        {
            if ((index > Length) || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (IsEmpty())
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
                if (index == 0)
                {
                    head = new Node(value, head);
                }
                else if (index == Length)
                {
                    tail.Next = new Node(value);
                    tail = tail.Next;
                }
                else
                {
                    var previous = FindNodeByIndex(index - 1);
                    var current = new Node(value, previous.Next);
                    previous.Next = current;
                }
            }

            Length++;
        }

        /// <summary>
        /// Removes the item with the desired position.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        public void RemoveElementByIndex(int index)
        {
            if ((index >= Length) || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                var previous = FindNodeByIndex(index - 1);
                if (previous.Next.Next == null)
                {
                    tail = previous;
                    tail.Next = null;
                }
                else
                {
                    previous.Next = previous.Next.Next;
                }
            }

            if (IsEmpty()) tail = null;
            Length--;
        }

        /// <summary>
        /// Returns the value of the item with the desired position.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        /// <returns>The value of the item with the desired position.</returns>
        public T GetValueByIndex(int index)
        {
            if ((index >= Length) || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return FindNodeByIndex(index).Value;
        }

        /// <summary>
        /// Sets the value of the item with the desired position.
        /// </summary>
        /// <param name="value">Desired value.</param>
        /// <param name="index">Position number counting from 0.</param>
        public void SetValueByIndex(T value, int index)
        {
            if ((index >= Length) || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            FindNodeByIndex(index).Value = value;
        }

        /// <summary>
        /// Prints the values of all items of LinkedList in the console.
        /// </summary>
        public void PrintList()
        {
            var current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
