using System;
using System.Collections.Generic;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<string> {"I", "am", "here"};

            var result = test.Fold(0, (seed, item) => seed + item.Length);
            
            Console.WriteLine(result);
        }
    }
}