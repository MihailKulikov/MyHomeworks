using System;

namespace SpiralOutput
{
    class Program
    {
        static void SpiralOutput(int[,] matrix)
        {
            int x = matrix.GetLength(0) / 2;
            int y = x;
            Console.Write($"{matrix[x, y]} ");
            int shift = 0;

            while (x != matrix.GetLength(0) - 1)
            {
                shift++;
                for (int i = 0; i < shift; ++i)
                {
                    y++;
                    Console.Write($"{matrix[x, y]} ");
                }
                for (int i = 0; i < shift; ++i)
                {
                    x--;
                    Console.Write($"{matrix[x, y]} ");
                }

                shift++;
                for (int i = 0; i < shift; ++i)
                {
                    y--;
                    Console.Write($"{matrix[x, y]} ");
                }
                for (int i = 0; i < shift; ++i)
                {
                    x++;
                    Console.Write($"{matrix[x, y]} ");
                }
            }

            for (int i = 1; i < matrix.GetLength(1); ++i)
            {
                y++;
                Console.Write($"{matrix[x, y]} ");
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] variables = input.Split(new char[] { ' ' });
            int N = int.Parse(variables[0]);
            int[,] matrix = new int[N, N];
            int index = 1;

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = int.Parse(variables[index]);
                    index++;
                }
            }

            SpiralOutput(matrix);
        }
    }
}
