using System;

namespace FibonacciNumbers
{
    class Program
    {
        static int Fib(int n)
        {
            int next = 1;
            int current = 0;
            for (int i = 0; i < n; ++i)
            {
                next += current;
                current = next - current;
            }

            return current;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n}-ое число Фибоначчи = {Fib(n)}");
        }
    }
}
