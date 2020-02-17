using System;

namespace Factorial
{
    class Program
    {
        private static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number whose factorial you want to calculate:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n}! = {Factorial(n)}"); 
        }
    }
}
