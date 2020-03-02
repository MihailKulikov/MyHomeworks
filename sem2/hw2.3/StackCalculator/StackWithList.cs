using System;

namespace StackCalculator
{
    public class StackWithList : IStack
    {
        private class Node
        {
            public double Value { get; }
            public Node Next { get; }

            public Node(double value)
            {
                Value = value;
            }
           
            public Node(double value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        public int Count { get; private set; }
        private Node _head;

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
