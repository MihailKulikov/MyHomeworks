﻿using System;

namespace StackCalculator
{
    public class StackWithArray : IStack
    {
        public int Count { get; private set; }
        private double[] _array;

        public StackWithArray() { _array = new double[0]; Count = 0; }

        public double Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
            var topOfStack = _array[0];
            var newArray = new double[Count - 1];
            Array.Copy(_array, 1, newArray, 0, newArray.Length);
            _array = newArray;
            Count--;
            return topOfStack;
        }

        public void Push(double value)
        {
            var newArray = new double[Count + 1];
            _array.CopyTo(newArray, 1);
            _array = newArray;
            _array[0] = value;
            Count++;
        }
    }
}
