using System;
namespace HashTableTask
{
    internal static class Program
    {
        private static void Main()
        {
            var hashTable = new HashTable(Console.Out, new PolynomialRollingHashFunction()) {"test1", "test2"};
            hashTable.Print();
            hashTable.Add("test3");
            hashTable.Add("test4");
            hashTable.Print();
            hashTable.Add("test5");
            hashTable.Add("test6");
            hashTable.Add("test7");
            hashTable.Print();
            hashTable.Remove("test1");
            hashTable.Remove("test1");
            hashTable.Remove("test4");
            hashTable.Remove("test228");
            hashTable.Remove("test6");
            Console.WriteLine($"\nis \"test7\" in hashTable? {hashTable.IsContains("test7")}");
            hashTable.ChangeHashFunction(new StandardHashFunction());
            Console.WriteLine($"is \"test4\" in hashTable? {hashTable.IsContains("test4")}\n");
            hashTable.Print();
        }
    }
}
