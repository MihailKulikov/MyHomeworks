using System;

namespace LinkedListRealisation
{
    internal class Program
    {
        private static void Main()
        {
            var list = new LinkedList<int>();
            list.AddElementByIndex(12, 0);
            list.AddElementByIndex(45, 1);
            list.AddElementByIndex(34, 1);
            Console.WriteLine(list.Length);
            list.AddElementByIndex(14, 0);
            list.RemoveElementByIndex(0);
            list.PrintList();
            list.RemoveElementByIndex(list.Length - 1);
            Console.WriteLine(list.GetValueByIndex(1));
            list.SetValueByIndex(1,1);
            list.PrintList();
        }
    }
}
