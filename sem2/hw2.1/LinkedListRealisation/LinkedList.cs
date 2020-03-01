using System;

namespace LinkedListRealisation
{
    public class LinkedList<T>
    {
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

        public bool IsEmpty()
            => Head == null;

        private Node FindNodeByIndex(int index)
        {
            var current = Head;
            for (var i = 0; i < index; i++)
            {
                current = current.Next ?? throw new ArgumentOutOfRangeException(nameof(index));
            }

            return current;
        }

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

        public T GetValueByIndex(int index)
        {
            if ((index >= Length) || (index < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return FindNodeByIndex(index).Value;
        }

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

        public void PrintList()
        {
            var current = Head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
