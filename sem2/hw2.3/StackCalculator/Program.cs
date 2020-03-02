using System;

namespace StackCalculator
{
    static class Program
    {
       internal static void Main()
       {
            Console.WriteLine("What type of stack do you prefer?");
            Console.WriteLine("1. With array.");
            Console.WriteLine("2. With list.");
            var typeOfList = Console.ReadLine();
            Console.WriteLine("Enter expression in reverse polish notation.");
            switch (typeOfList)
            {
                case "1":
                {
                    var stack = new StackWithArray();
                    var stackCalculator = new StackCalculator(stack);
                    stackCalculator.ExecuteLine(Console.ReadLine());
                    break;
                }
                case "2":
                {
                    var stack = new StackWithList();
                    var stackCalculator = new StackCalculator(stack);
                    stackCalculator.ExecuteLine(Console.ReadLine());
                    break;
                }
                default:
                {
                    throw new Exception("Incorrect type of stack.");
                }
            }
       }
    }
}
