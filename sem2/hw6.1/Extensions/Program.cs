using System;
using System.Collections.Generic;

namespace Extensions
{
    internal static class Program
    {
        private static void Main()
        {
            var test = new List<string> {"I", "am", "here"};

            var result = test.Fold(0, (seed, item) => seed + item.Length);
            
            Console.WriteLine(result);
        }
    }
}