using System;

namespace FibonacciNumbers
{
    class Program
    {
        private static int Fib(int position)
        {
            int next = 1;
            int current = 0;
            for (var i = 0; i < position; ++i)
            {
                next += current;
                current = next - current;
            }

            return current;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the position number of the desired fibonacci number");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine($"{position}th Fibonacci number = {Fib(position)}");
        }
    }
}
