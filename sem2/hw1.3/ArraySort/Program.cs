using System;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());
            var buffer = new int[size];
            Console.WriteLine("Enter elements of the array:");
            for (var i = 0; i < buffer.Length; ++i)
            {
                buffer[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(buffer);
            for (var i = 0; i < buffer.Length; ++i)
            {
                Console.Write($"{buffer[i]} ");
            }
        }
    }
}
