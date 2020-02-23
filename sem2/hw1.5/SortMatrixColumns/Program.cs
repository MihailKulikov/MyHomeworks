using System;
using System.Linq;

namespace SortMatrixColumns
{
    class Program
    {
        private static void Swap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }

        private static void SortMatrixColumns(int [,] matrix)
        {
            var step = matrix.GetLength(1) / 2;
            while (step >= 1)
            {
                for (var i = step; i < matrix.GetLength(1); i++)
                {
                    var j = i;
                    while ((j >= step) && (matrix[0, j - step] > matrix[0, j]))
                    {
                        for (var k = 0; k < matrix.GetLength(0); k++)
                        {
                            Swap(ref matrix[k, j - step], ref matrix[k, j]);
                        }
                        j = j - step;
                    }
                }

                step = step / 2;
            }
        }

        private static  void GetMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                Console.WriteLine($"Enter the elements of the {i + 1}th row of the matrix separated by space:");
                var variables = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = variables[j];
                }
            }
        }

        private static void PrintMatrix(int [,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the numbers of rows:");
            int rowCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int columnCount = int.Parse(Console.ReadLine());
            var matrix = new int[rowCount, columnCount];
            GetMatrix(matrix);
            SortMatrixColumns(matrix);
            PrintMatrix(matrix);
        }
    }
}
