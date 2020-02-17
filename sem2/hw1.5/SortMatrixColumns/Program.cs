using System;

namespace SortMatrixColumns
{
    public class Column : IComparable<Column>
    {
        public int[] elements;

        public int CompareTo(Column other)
        {
            if (other == null) return 1;

            return elements[0].CompareTo(other.elements[0]);
        }

        public Column(int[] elements)
        {
            this.elements = elements;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the numbers of rows:");
            int rowCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns:");
            int columnCount = int.Parse(Console.ReadLine());

            var matrix = new Column[columnCount];
            for (var i = 0; i < matrix.Length; ++i)
            {
                matrix[i] = new Column(new int[rowCount]);
            }

            Console.WriteLine("Enter matrix elements separated by space:");
            var input = Console.ReadLine();
            var variables = input.Split(new char[] { ' ' });
            var index = 0;

            for (var i = 0; i < rowCount; ++i)
            {
                for (var j = 0; j < matrix.Length; ++j)
                {
                    matrix[j].elements[i] = int.Parse(variables[index]);
                    index++;
                }
            }

            Array.Sort(matrix);

            for (var i = 0; i < rowCount; ++i)
            {
                for (var j = 0; j < matrix.Length; ++j)
                {
                    Console.Write($"{matrix[j].elements[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
