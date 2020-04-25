using System;
using System.IO;

namespace ExpressionTreeTask
{
    internal static class Program
    {
        private static void Main()
        {
            var parser = new Parser();

            var input = File.ReadAllText("input.txt");
            var tree = Parser.BuildTree(input);
            Console.WriteLine(tree.Print());
            Console.WriteLine(tree.Calculate());
        }
    }
}