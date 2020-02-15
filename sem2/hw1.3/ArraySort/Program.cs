using System;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var buffer = new int[size];
            for (int i = 0; i < buffer.Length; ++i)
            {
                buffer[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(buffer);
            for (int i = 0; i < buffer.Length; ++i)
            {
                Console.Write($"{buffer[i]} ");
            }
        }
    }
}
