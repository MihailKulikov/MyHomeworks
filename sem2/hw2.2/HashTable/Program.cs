using System;

namespace HashTable
{
    internal class Program
    {
        private static void Main()
        {
            var hashTable = new HashTable<string>();
            hashTable.Add("test1");
            hashTable.Add("test2");
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
            Console.WriteLine($"is \"test4\" in hashTable? {hashTable.IsContains("test4")}\n");
            hashTable.Print();
        }
    }
}
