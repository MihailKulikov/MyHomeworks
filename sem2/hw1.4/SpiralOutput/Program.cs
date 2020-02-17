using System;

namespace SpiralOutput
{
    class Program
    {
        private static void SpiralOutput(int[,] matrix)
        {
            int x = matrix.GetLength(0) / 2;
            var y = x;
            Console.Write($"{matrix[x, y]} ");
            var shift = 0;

            while (x != matrix.GetLength(0) - 1)
            {
                shift++;
                for (var i = 0; i < shift; ++i)
                {
                    y++;
                    Console.Write($"{matrix[x, y]} ");
                }
                for (var i = 0; i < shift; ++i)
                {
                    x--;
                    Console.Write($"{matrix[x, y]} ");
                }

                shift++;
                for (var i = 0; i < shift; ++i)
                {
                    y--;
                    Console.Write($"{matrix[x, y]} ");
                }
                for (var i = 0; i < shift; ++i)
                {
                    x++;
                    Console.Write($"{matrix[x, y]} ");
                }
            }

            for (var i = 1; i < matrix.GetLength(1); ++i)
            {
                y++;
                Console.Write($"{matrix[x, y]} ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the matrix:");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter elements of the matrix separated by space:");
            var variables = Console.ReadLine().Split(new char[] { ' ' });
            var matrix = new int[size, size];
            var index = 0;

            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = int.Parse(variables[index]);
                    index++;
                }
            }

            SpiralOutput(matrix);
        }
    }
}
