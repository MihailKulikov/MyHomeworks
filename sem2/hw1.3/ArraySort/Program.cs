using System;
using System.Linq;

namespace ArraySort
{
    class Program
    {
        private static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }

        private static void ShellSort(int[] array)
        {
            var step = array.Length / 2;
            while (step >= 1)
            {
                for (var i = step; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= step) && (array[j - step] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - step]);
                        j = j - step;
                    }
                }

                step = step / 2;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter elements of the array separated by space:");
            var buffer = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray() ;
            ShellSort(buffer);
            foreach (var i in buffer)
            {   
                Console.Write($"{i} ");
            }
        }
    }
}
