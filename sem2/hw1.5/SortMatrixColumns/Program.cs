using System;

namespace SortMatrixColumns
{
    public class Column : IComparable<Column>
    {
        public int CompareTo(Column other)
        {
            if (other == null) return 1;

            return elements[0].CompareTo(other.elements[0]);
        }

        public int[] elements;
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

            Column[] matrix = new Column[columnCount];
            for (int i = 0; i < matrix.Length; ++i)
            {
                matrix[i] = new Column(new int[rowCount]);
            }

            Console.WriteLine("Enter matrix elements with a space:");
            string input = Console.ReadLine();
            string[] variables = input.Split(new char[] { ' ' });
            int index = 0;

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < matrix.Length; ++j)
                {
                    matrix[j].elements[i] = int.Parse(variables[index]);
                    index++;
                }
            }

            Array.Sort<Column>(matrix);

            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < matrix.Length; ++j)
                {
                    Console.Write($"{matrix[j].elements[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
