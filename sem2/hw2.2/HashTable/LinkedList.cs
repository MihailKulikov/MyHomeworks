﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// Represents a singly linked list. Provides methods to search and manipulate lists.
    /// </summary>
    /// <typeparam name="T">Value type.</typeparam>
    public class LinkedList<T>:IEnumerable<T>
    {
        /// <summary>
        /// Represent the item of LinkedList.
        /// </summary>
        private class Node
        {
            public T Value { get; set; }

            public Node Next { get; set; }

            public Node(T value) => Value = value;

            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Length { get; private set; }

        /// <summary>
        /// Checks if the LinkedList is empty.
        /// </summary>
        /// <returns>True if LinkedList is empty, and false if not.</returns>
        public bool IsEmpty()
            => Head == null;

        /// <summary>
        /// Finds the item in Linked List with the desired position number.
        /// </summary>
        /// <param name="index">Position number counting from 0.</param>
        /// <returns>The item with the desired position number.</returns>
        private Node FindNodeByIndex(int index)
        {
            var current = Head;
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
                Head = new Node(value);
                Tail = Head;
            }
            else
            {
                if (index == 0)
                {
                    Head = new Node(value, Head);
                }
                else if (index == Length)
                {
                    Tail.Next = new Node(value);
                    Tail = Tail.Next;
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
                Head = Head.Next;
            }
            else
            {
                var previous = FindNodeByIndex(index - 1);
                if (previous.Next.Next == null)
                {
                    Tail = previous;
                    Tail.Next = null;
                }
                else
                {
                    previous.Next = previous.Next.Next;
                }
            }

            if (IsEmpty()) Tail = null;
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
            var current = Head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }

        /// <summary>
        /// Checks for the item with desirable value.
        /// </summary>
        /// <param name="value">Value of the item</param>
        /// <returns>True if contains, and false if not.</returns>
        public bool IsContains(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (IsEmpty()) return false;
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes item with desirable value from LinkedList.
        /// </summary>
        /// <param name="value">Value of the item.</param>
        /// <returns>True if item was removed, and false if not</returns>
        public bool RemoveItemsByValue(T value)
        {
            if (value == null)
            {
                throw  new ArgumentNullException(nameof(value));
            }
            Node current = Head;
            Node previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                    }
                    Length--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
